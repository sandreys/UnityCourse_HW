using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public PlayerInput _playerInput;

    private PlayerInput.PlayerActions _playerActions;


    private PlayerMotor _motor;
    private PlayerLook _look;
    private PlayerSwitchWeapon _switchWeapon;
    private ThrowGranade _throwGranade;

    private event Action<bool> _onMovementStateChanged;
    public bool IsMoving;


    private void Awake()
    {
        Instance = this;
        
        _playerInput = new PlayerInput();
        _playerActions = _playerInput.Player;
        
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _switchWeapon = GetComponent<PlayerSwitchWeapon>();
        _throwGranade = GetComponent<ThrowGranade>();

        _playerActions.Movement.performed += context => CheckMovementState();
        _playerActions.Movement.canceled += context => CheckMovementState();
        _playerActions.Jump.performed += context => _motor.Jump();
        _playerActions.SwitchWeapon.performed += context => _switchWeapon.SwitchWeapon((_switchWeapon.weaponIndicator < 1) ? ++_switchWeapon.weaponIndicator : 0);
        _playerActions.ThrowGranade.performed += context => _throwGranade.Throw();
    }

    public void FixedUpdate()
    {
        _motor.ProcessMove(_playerActions.Movement.ReadValue<Vector2>());
        
    }
    public void LateUpdate()
    {
        _look.ProcessLook(_playerActions.Look.ReadValue<Vector2>());

    }
    private void OnEnable()
    {

        _playerActions.Enable();

    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    public bool CheckMovementState()
    {
        Vector2 movementInput = _playerActions.Movement.ReadValue<Vector2>();
        bool newIsMoving = movementInput.magnitude > 0.1f;

        if (newIsMoving != IsMoving)
        {
            IsMoving = newIsMoving;
            _onMovementStateChanged?.Invoke(IsMoving);
        }

        return IsMoving;
    }


}
