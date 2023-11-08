using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine StateMachine;
    public AIStateID InitialState;
    public NavMeshAgent NavMeshAgent;
    public Ragdoll Ragdoll;
    public Animator Animator;
    public AIAgentConfig Config;
    public Transform PlayerTransform;
    public WeaponIk Weapon;
    
    public void Start()
    {      
        Ragdoll = GetComponent<Ragdoll>();
        Animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        StateMachine = new AIStateMachine(this);
        StateMachine.RegisterState(new AIChasePlayerState());
        StateMachine.RegisterState(new AIDeathState());
        StateMachine.RegisterState(new AIIdleState());
        StateMachine.RegisterState(new AiAttackPlayerState());
        StateMachine.ChangeState(InitialState);
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {      
        StateMachine.Update();      
    }
}
