using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject failedPanel;

    private void Awake()
    {
        successPanel.SetActive(false);
        failedPanel.SetActive(false);
    }

    public void Initialize(bool isWin)
    {
        successPanel.SetActive(isWin);
        failedPanel.SetActive(!isWin);
    }

    public void OnContinueButtonTap()
    {
        GameController.Instance.LoadMainMenu(true);
    }

    public void OnRetryButtonTap()
    {
        GameController.Instance.LoadMainMenu(false);
    }
}
