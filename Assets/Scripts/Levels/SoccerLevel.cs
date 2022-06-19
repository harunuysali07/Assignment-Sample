using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerLevel : LevelBase
{
    [HideInInspector] public SoccerBall soccerBall;
    public override LevelBase Initialize()
    {
        levelType = LevelType.Soccer;

        return base.Initialize();
    }
}
