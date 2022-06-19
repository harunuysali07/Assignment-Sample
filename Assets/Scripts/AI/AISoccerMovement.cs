using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISoccerMovement : AIMovement
{
    private SoccerBall soccerBall;
    private void Start()
    {
        var soccerLevel = LevelManager.Instance.currentLevel as SoccerLevel;
        soccerBall = soccerLevel.soccerBall;
    }
    protected override void Move()
    {
        if (!agentBase.agent.isOnNavMesh)
            return;

        var direction = ((soccerBall.transform.position + Vector3.forward * .4f) - transform.position).normalized;

        agentBase.agent.Move(direction * agentBase.agent.speed * Time.deltaTime);

        Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 30 * Time.deltaTime);
    }
}
