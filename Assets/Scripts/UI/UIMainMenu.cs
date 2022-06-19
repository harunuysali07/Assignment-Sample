using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;

    void Start()
    {
        levelText.text = "Level " + (DataManager.CurrentLevel + 1);
    }

    public void OnStartButtonTap()
    {
        GameController.Instance.LevelStarted();
    }
}
