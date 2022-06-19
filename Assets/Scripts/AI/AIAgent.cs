using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : AgentBase
{
    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    public override void Start()
    {
        LevelManager.Instance.currentLevel.enemyCount++;

        SetMovementType(LevelManager.Instance.currentLevel.levelType);

        base.Start();
    }

    public void SetMovementType(LevelType levelType)
    {
        switch (levelType)
        {
            default:
            case LevelType.Tiles:
                movement = gameObject.AddComponent<AITileMovement>().Initialize(this);
                break;
            case LevelType.Soccer:
                movement = gameObject.AddComponent<AISoccerMovement>().Initialize(this);
                break;
        }
    }

    public override void Die()
    {
        base.Die();

        LevelManager.Instance.currentLevel.enemyCount--;

        if (GameController.GameState && LevelManager.Instance.currentLevel.enemyCount == 0)
        {
            GameController.Instance.LevelCompleted();
        }
    }
}
