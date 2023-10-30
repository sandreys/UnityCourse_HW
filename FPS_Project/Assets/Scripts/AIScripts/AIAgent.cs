using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine StateMachine;
    public AIStateID initialState;
    public NavMeshAgent navMeshAgent;
    public Ragdoll Ragdoll;
    public Animator Animator;
    public AIAgentConfig config;
    public Transform playerTransform;
    public WeaponIk weapon;
    
    public void Start()
    {      
        Ragdoll = GetComponent<Ragdoll>();
        Animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        StateMachine = new AIStateMachine(this);
        StateMachine.RegisterState(new AIChasePlayerState());
        StateMachine.RegisterState(new AIDeathState());
        StateMachine.RegisterState(new AIIdleState());
        StateMachine.RegisterState(new AiAttackPlayerState());
        StateMachine.ChangeState(initialState);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {      
        StateMachine.Update();      
    }
}
