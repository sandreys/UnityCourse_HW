using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent agent;
    public Animator animator;

   
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {

        if (agent.hasPath)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
     
    }
}
