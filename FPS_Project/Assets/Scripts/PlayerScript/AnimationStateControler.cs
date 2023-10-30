using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationStateControler : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput.PlayerActions _action;

    public void Start()
    {
        _action = InputManager.Instance._playerInput.Player;
        _animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (_action.Movement.IsInProgress())
        { 
            _animator.SetBool("IsWalking", true);
        }else
        {   
            _animator.SetBool("IsWalking", false);
        }
    }

}
