using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 50f;
    [SerializeField] private float _force = 50f;
    [SerializeField] private float _rayDistance = 0.1f;
    [SerializeField] private Transform _startPoint;

    private RaycastHit _hit;
    private Ray _ray;

    public Transform Pointer;
    public void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
 
        if (Physics.SphereCast(_ray, _rayDistance, out _hit))
        {
            Pointer.position = _hit.point;

            if (_hit.collider.gameObject.tag == "Enemy")
            {
                StartExplosion();
                Destroy(gameObject);
            }
        }

    }

    private void StartExplosion()
    {
        var objects = Physics.SphereCastAll(_startPoint.position, _radius, _startPoint.up);
        foreach (var raycastHit in objects)
        {
            if (raycastHit.rigidbody is not null)
            {
                raycastHit.rigidbody.AddExplosionForce(_force, _startPoint.position, _radius);
            }        
        }
    }
}
