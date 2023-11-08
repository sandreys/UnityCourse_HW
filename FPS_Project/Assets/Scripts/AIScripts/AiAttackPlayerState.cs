using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackPlayerState : AiState
{
   
    public void Enter(AIAgent agent)
    {
        agent.Weapon.SetTarget(agent.PlayerTransform);
        agent.NavMeshAgent.stoppingDistance = 10f;
    }

    public void Exit(AIAgent agent)
    {
      
        agent.NavMeshAgent.stoppingDistance = 0f;
        
    }

    public AIStateID GetID()
    {
        return AIStateID.AttackPlayer;
    }

    public void Update(AIAgent agent)
    {
       
        agent.NavMeshAgent.destination = agent.PlayerTransform.position;

        RaycastHit hit;
        Vector3 directionToPlayer = agent.PlayerTransform.position - agent.transform.position;

        if (Physics.Raycast(agent.transform.position, directionToPlayer, out hit))
        {
            if (hit.transform.tag == "PlayerHitBox")
            {
                float angle = 45f;
                float angleToPlayer = Vector3.Angle(agent.transform.forward, directionToPlayer);
                if (angleToPlayer < angle)
                {
                    agent.Weapon.Shoot();
                }
                else
                {
                    
                    agent.StateMachine.ChangeState(AIStateID.ChasePlayer);
                }
                    

            }

        }
    }

    }

