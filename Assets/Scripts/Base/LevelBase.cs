using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase : MonoBehaviour
{
    [HideInInspector] public LevelType levelType;
    [HideInInspector] public int enemyCount = 0;

    public virtual LevelBase Initialize()
    {
        enemyCount = 0;

        return this;
    }
}

public enum LevelType
{
    Tiles,
    Soccer
}
