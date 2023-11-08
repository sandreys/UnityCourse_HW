using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIk : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private float _shootDelay = 0.5f;

    public Transform TargetTransform;
    public Transform AimTransform;
    public Transform Bone;

    public ParticleSystem FireFlash;
    public ParticleSystem BulletEffect;

    private TakeDamage _playerTakeDamage;
    private Audio Audio;
    

    public int Iterations = 10;
    public float AngleLimit = 90f;
    public float DistanceLimit = 1.5f;

    [Range(0, 1)]
    public float Weight = 1.0f;

    private bool _canShoot = true;

    public void Start()
    {
        TargetTransform = GameObject.FindWithTag("Player").transform;
        Audio = GetComponent<Audio>();
    }
    public void LateUpdate()
    {
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < Iterations; i++)
        {
            AimAtTarget(Bone, targetPosition, Weight);
        }

    }

    private Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = TargetTransform.position - AimTransform.position;
        Vector3 aimDirection = AimTransform.forward;
        float blendOut = 0.0f;

        float targetAngel = Vector3.Angle(targetDirection, aimDirection);
        if (targetAngel > AngleLimit)
        {
            blendOut += (targetAngel - AngleLimit) / 50.0f;
        }
        float targetDistance = targetDirection.magnitude;
        if (targetDistance < DistanceLimit)
        {
            blendOut += DistanceLimit - targetDistance;
        }
        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return AimTransform.position + direction;
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = AimTransform.forward;
        Vector3 targetDirection = targetPosition - AimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }

    public void Shoot()
    {
        if (_canShoot == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(AimTransform.position, AimTransform.forward, out hit))
            {


                StartCoroutine(ShootCooldown());
                CheckAiHit(hit);



            }
        }
    }

    public void CheckAiHit(RaycastHit hit)
    {
        Instantiate(BulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
        FireFlash.Play();
        Audio.FireSound();
        try
        {
            _playerTakeDamage = hit.transform.GetComponent<TakeDamage>();

            Debug.Log(_playerTakeDamage.DamageType);
            switch (_playerTakeDamage.DamageType)
            {
                case TakeDamage.collisionType.Head:
                    Debug.Log("Head");
                    _playerTakeDamage.PlayerHit(_damageAmount);
                    break;
                case TakeDamage.collisionType.Body:
                    _playerTakeDamage.PlayerHit(_damageAmount / _playerTakeDamage.BodyTakeDamageDecrease);
                    break;
                case TakeDamage.collisionType.Arms:
                    _playerTakeDamage.PlayerHit(_damageAmount / _playerTakeDamage.ArmsTakeDamageDecrease);
                    break;
            }
        }
        catch
        {

        }
    }
    public void SetTarget(Transform target)
    {
        TargetTransform = target;
    }

    private IEnumerator ShootCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_shootDelay);
        _canShoot = true;
    }
}
