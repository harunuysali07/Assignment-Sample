using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerInteraction : InteractionBase
{
    public override InteractionBase Initialize(AgentBase _agentBase)
    {
        var interactionCollider = gameObject.AddComponent<CapsuleCollider>();
        interactionCollider.center = Vector3.up * .75f;
        interactionCollider.radius = 0.5f;
        interactionCollider.height = 1.5f;

        return base.Initialize(_agentBase);
    }

    private const float ShootInterval = .25f;
    private float shootTimer = 0f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Soccer Ball"))
        {
            if (shootTimer > Time.time)
                return;

            shootTimer = Time.time + ShootInterval;
            other.rigidbody.AddForceAtPosition(Vector3.up * 5f + transform.forward * 4f, transform.position, ForceMode.Impulse);

            agentBase.movement.SoccerKick();
        }
    }
}
