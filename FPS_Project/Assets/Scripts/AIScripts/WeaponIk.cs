using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIk : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float _shootDelay = 0.5f;

    public Transform targetTransform;
    public Transform aimTransform;
    public Transform bone;

    public ParticleSystem FireFlash;
    public ParticleSystem BulletEffect;

    private TakeDamage _playerTakeDamage;
    private Audio Audio;
    private bool IsFiring;

    public int Iterations = 10;
    public float angleLimit = 90f;
    public float distanceLimit = 1.5f;

    [Range(0, 1)]
    public float weight = 1.0f;

    private bool _canShoot = true;

    public void Start()
    {
        targetTransform = GameObject.FindWithTag("Player").transform;
        Audio = GetComponent<Audio>();
    }
    public void LateUpdate()
    {
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < Iterations; i++)
        {
            AimAtTarget(bone, targetPosition, weight);
        }

    }

    private Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        float blendOut = 0.0f;

        float targetAngel = Vector3.Angle(targetDirection, aimDirection);
        if (targetAngel > angleLimit)
        {
            blendOut += (targetAngel - angleLimit) / 50.0f;
        }
        float targetDistance = targetDirection.magnitude;
        if (targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }
        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return aimTransform.position + direction;
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }

    public void Shoot()
    {
        if (_canShoot == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(aimTransform.position, aimTransform.forward, out hit))
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
                    _playerTakeDamage.PlayerHit(damageAmount);
                    break;
                case TakeDamage.collisionType.Body:
                    _playerTakeDamage.PlayerHit(damageAmount / _playerTakeDamage.BodyTakeDamageDecrease);
                    break;
                case TakeDamage.collisionType.Arms:
                    _playerTakeDamage.PlayerHit(damageAmount / _playerTakeDamage.ArmsTakeDamageDecrease);
                    break;
            }
        }
        catch
        {

        }
    }
    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }

    private IEnumerator ShootCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_shootDelay);
        _canShoot = true;
    }
}
