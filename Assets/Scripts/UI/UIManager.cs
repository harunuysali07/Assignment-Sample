using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UIMainMenu uiMainMenu;
    public UIGamePlay uiGamePlay;
    public UILevelEnd uiLevelEnd;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        uiMainMenu.gameObject.SetActive(false);
        uiGamePlay.gameObject.SetActive(false);
        uiLevelEnd.gameObject.SetActive(false);
    }

    private void Start()
    {
        uiMainMenu.gameObject.SetActive(true);

        GameController.Instance.OnLevelStart += OnLevelStart;
        GameController.Instance.OnLevelEnd += OnLevelEnd;
    }

    private void OnLevelStart()
    {
        uiMainMenu.gameObject.SetActive(false);
        uiGamePlay.gameObject.SetActive(true);
    }

    private void OnLevelEnd(bool isWin)
    {
        uiGamePlay.gameObject.SetActive(false);
        uiLevelEnd.gameObject.SetActive(true);
        uiLevelEnd.Initialize(isWin);
    }
}