using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : InteractionBase
{
    public override InteractionBase Initialize(AgentBase _agentBase)
    {
        var interactionCollider = gameObject.AddComponent<CapsuleCollider>();
        interactionCollider.center = Vector3.up;
        interactionCollider.radius = 0.25f;
        interactionCollider.height = 3f;
        interactionCollider.isTrigger = true;

        return base.Initialize(_agentBase);
    }

    public virtual void Update()
    {
        if (Physics.SphereCast(transform.position + .5f * Vector3.up, .1f, Vector3.down, out RaycastHit hit, 1f, 1 << LayerMask.NameToLayer("Tile")))
        {
            //Agent on a Hexagon
        }
        else
        {
            agentBase.Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + .5f * Vector3.up, Vector3.down);
    }
}
