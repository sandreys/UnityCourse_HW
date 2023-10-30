using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    public AiState[] States;
    public AIAgent Agent;
    public AIStateID CurrentState;
    public AIStateMachine(AIAgent agent)
    {
        this.Agent = agent;
        int numStates = System.Enum.GetNames(typeof(AIStateID)).Length;
        States = new AiState[numStates];
    }
    public void Update()
    {
        GetState(CurrentState)?.Update(Agent);
    }
    public void RegisterState(AiState state)
    {
        int index = (int)state.GetID();
        States[index] = state;
    }

    public AiState GetState(AIStateID stateId)
    {
        int index = (int)stateId;
        return States[index];
    }

    public void ChangeState(AIStateID newState)
    {
        GetState(CurrentState)?.Exit(Agent);
        CurrentState = newState;
        GetState(CurrentState)?.Enter(Agent);
    }
}
