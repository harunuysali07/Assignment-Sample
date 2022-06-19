using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovement : MovementBase
{
    private void Update()
    {
        if (GameController.GameState)
        {
            Move();
        }

        UpdateMovementSpeed();
    }

    protected virtual void Move()
    {
        
    }
}
