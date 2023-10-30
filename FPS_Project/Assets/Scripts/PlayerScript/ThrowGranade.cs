using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowGranade : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject throwGranade;

    [SerializeField] private int totalGranades;
    [SerializeField] private float throwCooldown;
    [SerializeField] private float throwForce;
    [SerializeField] private float throwUpForce;

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
        if (_isReadtToTrow && totalGranades > 0)
        {

            GameObject granade = Instantiate(throwGranade, attackPoint.position, camera.rotation);
            Rigidbody granadeRigidBody = granade.GetComponent<Rigidbody>();

            Vector3 addForce = camera.transform.forward * throwForce + transform.up * throwUpForce;
            granadeRigidBody.AddForce(addForce, ForceMode.Impulse);

            totalGranades--;

            Invoke(nameof(ThrowReset), throwCooldown);

        }
    }

    private void ThrowReset()
    {
        _isReadtToTrow = true;
    }
}
