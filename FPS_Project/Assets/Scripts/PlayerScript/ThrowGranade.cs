using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowGranade : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private GameObject _throwGranade;

    [SerializeField] private int _totalGranades;
    [SerializeField] private float _throwCooldown;
    [SerializeField] private float _throwForce;
    [SerializeField] private float _throwUpForce;

    private bool _isReadtToTrow;

    public void Start()
    {
        _isReadtToTrow = true;
    }

    public void Update()
    {


    }
    public void Throw()
    {
        if (_isReadtToTrow && _totalGranades > 0)
        {

            GameObject granade = Instantiate(_throwGranade, _attackPoint.position, _camera.rotation);
            Rigidbody granadeRigidBody = granade.GetComponent<Rigidbody>();

            Vector3 addForce = _camera.transform.forward * _throwForce + transform.up * _throwUpForce;
            granadeRigidBody.AddForce(addForce, ForceMode.Impulse);

            _totalGranades--;

            Invoke(nameof(ThrowReset), _throwCooldown);

        }
    }

    private void ThrowReset()
    {
        _isReadtToTrow = true;
    }
}
