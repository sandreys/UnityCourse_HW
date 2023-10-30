using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _jumpHeight = 3f;

    private CharacterController _characterController;
    public Audio Audio;
    public Vector3 _playerVelocity;

    private bool _isGrounded;

    public void Start()
    {
        Audio = GetComponent<Audio>();
        _characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _characterController.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
        if (InputManager.Instance.IsMoving)
        {
            StartCoroutine(Audio.MoveSound());
        }
    }

    

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }

}








