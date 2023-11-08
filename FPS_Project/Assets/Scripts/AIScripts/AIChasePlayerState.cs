using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AIChasePlayerState : AiState
{
    public Transform PlayerTransform;
    

    
    public float timer = 1.0f;

    public void Enter(AIAgent agent)
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
       

    }

    public void Exit(AIAgent agent)
    {
       
    }

    public AIStateID GetID()
    {
        return AIStateID.ChasePlayer;
    }

    public void Update(AIAgent agent)
    {
       
        if (!agent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (!agent.NavMeshAgent.hasPath)
        {
            agent.NavMeshAgent.destination = agent.PlayerTransform.position;
        }
        if (timer < 0)
        {
           
            Vector3 direction = (agent.PlayerTransform.position - agent.NavMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.Config.MaxDistance * agent.Config.MaxDistance)
            {
                if (agent.NavMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.NavMeshAgent.destination = agent.PlayerTransform.position;
                }
            }
            else
            {
                agent.StateMachine.ChangeState(AIStateID.AttackPlayer);
                Debug.Log(agent.StateMachine.CurrentState);
            }   
            timer = agent.Config.MaxTime;
        }


    }
}
