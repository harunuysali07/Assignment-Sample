using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : AgentBase
{
    public static PlayerAgent Instance;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        Initialize();
    }

    public override void Die()
    {
        base.Die();

        if (GameController.GameState)
        {
            GameController.Instance.LevelFailed();
        }
    }
}
