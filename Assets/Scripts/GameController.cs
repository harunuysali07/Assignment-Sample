using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static bool GameState = false;

    public UnityAction OnLevelStart;
    public UnityAction<bool> OnLevelEnd;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameState = false;
    }

    public void LevelStarted()
    {
        OnLevelStart?.Invoke();
        GameState = true;
    }

    public void LevelCompleted()
    {
        OnLevelEnd?.Invoke(true);
        GameState = false;
    }

    public void LevelFailed()
    {
        OnLevelEnd?.Invoke(false);
        GameState = false;
    }

    public void LoadMainMenu(bool isWin = true)
    {
        if (isWin)
            DataManager.CurrentLevel++;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
