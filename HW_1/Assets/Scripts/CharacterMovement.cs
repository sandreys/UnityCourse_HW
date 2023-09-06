using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _body;
    void Start()
    {
        _body = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }
    }
    private void Movement(Vector3 direction)
    {
        _body.velocity = direction * _speed;
        float _angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, _angle, 0);

    }
}
