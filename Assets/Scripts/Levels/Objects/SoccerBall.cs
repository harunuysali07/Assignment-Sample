using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Start()
    {
        GameController.Instance.OnLevelStart += OnLevelStart;
        GameController.Instance.OnLevelEnd += OnLevelEnd;

        var soccerLevel = LevelManager.Instance.currentLevel as SoccerLevel;
        soccerLevel.soccerBall = this;
    }

    private void OnLevelEnd(bool _)
    {
        rb.isKinematic = true;
    }

    private void OnLevelStart()
    {
        rb.isKinematic = false;
    }

    private void OnDestroy()
    {
        GameController.Instance.OnLevelStart -= OnLevelStart;
        GameController.Instance.OnLevelEnd -= OnLevelEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soccer Goal") && GameController.GameState)
        {
            var goal = other.GetComponent<SoccerGoal>();

            if (goal.goalType == GoalType.Player)
            {
                GameController.Instance.LevelFailed();
            }
            else
            {
                GameController.Instance.LevelCompleted();
            }

            goal.OnGoal();
        }
    }
}
