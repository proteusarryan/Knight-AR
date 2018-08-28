﻿using GoogleARCore.HelloAR;
using UnityEngine;

public enum GamePlayMode
{
    Normal = 0,
    AR = 1
}

public class GameManager : CustomMonoBehaviour
{
    [Space]
    public ScreenUIController screenUIController;
    [Space]
    public ObjectPoolManager objectPoolManager;

    public PlayerController playerController { get; set; }
    public EnemyController enemyController { get; set; }

    public GamePlayMode gamePlayMode { get; private set; }

    public static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Space]
    public float characterLocalScaleForAR = 0.1f;

    void OnEnable()
    {
        if (!instance)
        {
            instance = this;
        }

        if (!screenUIController) screenUIController = FindObjectOfType<ScreenUIController>();
        if (!objectPoolManager) objectPoolManager = FindObjectOfType<ObjectPoolManager>();

        //gamePlayMode = FindObjectOfType<GameManagerAR>() == null ? GamePlayMode.Normal : GamePlayMode.AR;
        gamePlayMode = FindObjectOfType<GameController>() == null ? GamePlayMode.Normal : GamePlayMode.AR;
    }

    public void PlayAgain()
    {
        ReviveAllCharacters();
    }

    public void ReviveAllCharacters()
    {
        playerController.Revive();
        enemyController.Revive();
    }
}