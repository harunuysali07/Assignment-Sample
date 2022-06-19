using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class AgentBase : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public MovementBase movement;
    [HideInInspector] public InteractionBase interaction;


    public virtual void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        movement = GetComponent<MovementBase>().Initialize(this);
    }

    public virtual void Start()
    {
        SetInteractionType(LevelManager.Instance.currentLevel.levelType);
    }

    public void SetInteractionType(LevelType levelType)
    {
        switch (levelType)
        {
            default:
            case LevelType.Tiles:
                interaction = gameObject.AddComponent<TileInteraction>().Initialize(this);
                break;
            case LevelType.Soccer:
                interaction = gameObject.AddComponent<SoccerInteraction>().Initialize(this);
                break;
        }
    }

    public virtual void ChangeRagdollState(bool state)
    {
        var mainRigid = GetComponent<Rigidbody>();

        foreach (var rigid in GetComponentsInChildren<Rigidbody>())
        {
            if (rigid == mainRigid)
                continue;

            rigid.isKinematic = !state;
        }

    }

    public virtual void Die()
    {
        agent.isStopped = true;
        agent.updatePosition = false;
        agent.updateRotation = false;

        animator.enabled = false;

        interaction.enabled = false;

        ChangeRagdollState(true);
    }
}
