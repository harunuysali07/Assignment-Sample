using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionBase : MonoBehaviour
{
    [HideInInspector] public AgentBase agentBase;

    public virtual InteractionBase Initialize(AgentBase _agentBase)
    {
        agentBase = _agentBase;

        return this;
    }
}
