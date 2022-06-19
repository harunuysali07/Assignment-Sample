using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MovementBase : MonoBehaviour
{
    [HideInInspector] public AgentBase agentBase;

    public virtual MovementBase Initialize(AgentBase agent)
    {
        agentBase = agent;

        return this;
    }

    private Vector3 lastPosition;
    private float blendTreeSpeed = 0;

    protected void UpdateMovementSpeed()
    {
        blendTreeSpeed = Mathf.Lerp(blendTreeSpeed, Mathf.Clamp01((lastPosition - transform.position).magnitude * 10f), 10 * Time.deltaTime);
        agentBase.animator.SetFloat(AnimatorParameters.MovementSpeed, blendTreeSpeed);
        lastPosition = transform.position;
    }

    public void SoccerKick()
    {
        agentBase.animator.SetTrigger(AnimatorParameters.SoccerKick);
    }

    public void StartPush()
    {
        agentBase.animator.SetBool(AnimatorParameters.IsPushing, true);
    }

    public void StopPush()
    {
        agentBase.animator.SetBool(AnimatorParameters.IsPushing, false);
    }

    private struct AnimatorParameters
    {
        public const string MovementSpeed = "Movement Speed";
        public const string IsPushing = "IsPushing";
        public const string SoccerKick = "Soccer Kick";
    }
}

