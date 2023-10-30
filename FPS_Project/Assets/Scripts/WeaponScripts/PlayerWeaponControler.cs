    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerWeaponControler : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private bool _isAutomatic;
    [SerializeField] private float _force;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int magazineSize;
    [SerializeField] private int _ammoLeft;
    [SerializeField] private int _ammo;
    [SerializeField] private int _ammoMax;
    [SerializeField] private int damageAmount;

    private Animator _animations;
    private PlayerInput _inputActions;
    private TakeDamage _takeDamage;

    public GameObject CameraGameObject;
    public ParticleSystem FireFlash;
    public ParticleSystem BulletEffect;

    public Audio Audio;

    private bool _isShooting;
    private bool _readyToShoot;
    private bool _reloading;
    
    private int _animationSwiter = 1;
 
    public void Start()
    {
        _animations = gameObject.GetComponent<Animator>();
        Audio = gameObject.GetComponent<Audio>();

    }
    public void Awake()
    {
        _inputActions = new PlayerInput();
        _readyToShoot = true;
        _inputActions.Player.Shoot.started += contex => StartShoot();
        _inputActions.Player.Shoot.canceled += contex => EndShoot();
        _inputActions.Player.Reload.performed += contex => Reload();
        
    }

    private void Update()
    {
        StartCoroutine(AnimateMoving(Time.deltaTime));

            if (_isShooting && _readyToShoot && !_reloading && _ammoLeft > 0)
        {
            PerformShot();
            StartCoroutine(AnimateShooting(Time.deltaTime));
        }
    }
    public void StartShoot()
    {
        _isShooting = true;
    }

    public void EndShoot()
    {
        _isShooting = false;
        Debug.Log("EndShoot");
    }
    private void ResetShoot()
    {
        _readyToShoot = true;
    }

    public void PerformShot()
    {
        _takeDamage = null;
        _readyToShoot = false;

        FireFlash.Play();
        Audio.FireSound();
        RaycastHit hit;

        if (Physics.Raycast(CameraGameObject.transform.position, CameraGameObject.transform.forward, out hit))
        {
           CheckHit(hit);
        }

        _ammoLeft--;
        PlayerPrefs.SetInt("CurrentAmmo", _ammoLeft);

        if (_ammoLeft >= 0)
        {
            Invoke("ResetShoot", _fireRate);

            if (!_isAutomatic)
            {
                EndShoot();
            }
        }
    }
    private void CheckHit(RaycastHit hit)
    {
        if (hit.rigidbody != null)
        {
            
            hit.rigidbody.AddForce(-hit.normal * _force);
        }
        Instantiate(BulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Debug.Log("HITTTT");
        try
        {
            _takeDamage = hit.transform.GetComponent<TakeDamage>();
            Debug.Log(_takeDamage.DamageType);
            switch (_takeDamage.DamageType)
            {
                case TakeDamage.collisionType.Head:
                    Debug.Log("Head");
                    _takeDamage.Hit(damageAmount);
                    break;
                case TakeDamage.collisionType.Body:
                    _takeDamage.Hit(damageAmount / _takeDamage.BodyTakeDamageDecrease);
                    break;
                case TakeDamage.collisionType.Arms:
                    _takeDamage.Hit(damageAmount / _takeDamage.ArmsTakeDamageDecrease);
                    break;
            }
        }
        catch
        {

        }
    }
    private void Reload()
    {
        if (!_reloading && _ammo > 0)
        {
            Debug.Log("Start Reloading");
            StartCoroutine(AnimateReload(_reloadTime));
            Audio.ReloadSound();
            int missingAmmo = magazineSize - _ammoLeft;

            if (_ammo >= missingAmmo)
            {
                _ammo -= missingAmmo;
                _ammoLeft = magazineSize;
            }
            else
            {
                if (_ammo > 0)
                {
                    _ammoLeft += _ammo;
                    _ammo = 0;
                }
            }
            PlayerPrefs.SetInt("LeftAmmo", _ammo);
            PlayerPrefs.SetInt("CurrentAmmo", _ammoLeft);
        }


    }
    public void GetAmmo()
    {
        _ammo = _ammoMax;
    }
    private void OnEnable()
    {
        _inputActions.Enable();
        PlayerPrefs.SetInt("CurrentAmmo", _ammoLeft);
        PlayerPrefs.SetInt("LeftAmmo", _ammo);
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private IEnumerator AnimateShooting(float delay)
    {
        _animations.SetInteger("Fire", _animationSwiter);
        yield return new WaitForSeconds(delay);
        _animations.SetInteger("Fire", -_animationSwiter);
    }
    private IEnumerator AnimateMoving(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animations.SetInteger("Movement", (InputManager.Instance.CheckMovementState()) ? _animationSwiter : 0);
    }
    private IEnumerator AnimateReload(float reloadTime)
    {
        _reloading = true;
        _animations.SetInteger("Reload", _animationSwiter);
        yield return new WaitForSeconds(reloadTime);
        _animations.SetInteger("Reload", -_animationSwiter);
        _reloading = false;
    }

}
