using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [HideInInspector] public LevelBase currentLevel;

    [SerializeField] private List<LevelBase> Levels = new List<LevelBase>();

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        Initialize();
    }

    private void Initialize()
    {
        var level = Levels[DataManager.CurrentLevel % Levels.Count];
        Instantiate(level);

        currentLevel = level.Initialize();
    }
}
