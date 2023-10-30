using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AiState
{
    private float _spawnDelay = 3f;
    public void Enter(AIAgent agent)
    {
        agent.Ragdoll.ActivateRagdoll();
        agent.Animator.enabled = false;
        agent.navMeshAgent.enabled = false;
        agent.weapon.enabled = false;
        agent.StartCoroutine(Spawner.instance.SpawnEnemyWithDelay(_spawnDelay));
        Object.Destroy(agent.gameObject, _spawnDelay + 0.1f);

    }

    public void Exit(AIAgent agent)
    {

    }

    public AIStateID GetID()
    {
        return AIStateID.Death;
    }

    public void Update(AIAgent agent)
    {

    }

    
}
