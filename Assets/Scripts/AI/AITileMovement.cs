using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITileMovement : AIMovement
{
    protected override void Move()
    {
        if (!agentBase.agent.isOnNavMesh)
            return;

        if (agentBase.agent.remainingDistance <= agentBase.agent.stoppingDistance)
        {
            var randomOFfset = Random.insideUnitSphere.x * Vector3.right + Random.insideUnitSphere.z * Vector3.forward;
            randomOFfset *= 5f;

            if (Physics.SphereCast(transform.position + .5f * Vector3.up + randomOFfset, .1f, Vector3.down, out RaycastHit hit, 1f, 1 << LayerMask.NameToLayer("Tile")))
            {
                agentBase.agent.SetDestination(hit.point);
            }
        }
    }
}
