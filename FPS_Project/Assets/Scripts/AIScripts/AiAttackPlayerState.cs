using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackPlayerState : AiState
{
   
    public void Enter(AIAgent agent)
    {
        agent.weapon.SetTarget(agent.playerTransform);
        agent.navMeshAgent.stoppingDistance = 10f;
    }

    public void Exit(AIAgent agent)
    {
      
        agent.navMeshAgent.stoppingDistance = 0f;
        
    }

    public AIStateID GetID()
    {
        return AIStateID.AttackPlayer;
    }

    public void Update(AIAgent agent)
    {
       
        agent.navMeshAgent.destination = agent.playerTransform.position;

        RaycastHit hit;
        Vector3 directionToPlayer = agent.playerTransform.position - agent.transform.position;

        if (Physics.Raycast(agent.transform.position, directionToPlayer, out hit))
        {
            if (hit.transform.tag == "PlayerHitBox")
            {
                float angle = 45f;
                float angleToPlayer = Vector3.Angle(agent.transform.forward, directionToPlayer);
                if (angleToPlayer < angle)
                {
                    agent.weapon.Shoot();
                }
                else
                {
                    
                    agent.StateMachine.ChangeState(AIStateID.ChasePlayer);
                }
                    

            }

        }
    }

    }

