using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private static AppManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
