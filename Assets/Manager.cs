using System;
using UnityEngine;

public class Manager : MonoBehaviour {
    // private static Manager _instance;

    public static Manager Instance;
    private Spawner _spawner;

    public bool gameOver = false;
    public bool mainMenu = true;

   
    public int Score = 0;

    private void Awake() {
        Instance = this;
        Player.Instance._healthManager.OnDead += GameOver;

        _spawner = FindObjectOfType<Spawner>();
        Score = 0;
    }

    private void GameOver() {
        gameOver = true;
        Time.timeScale = 0.2f;
    }


    public static void IncreaseScore(int value = 10) {
        if (Instance.gameOver) return;
        Instance.Score += value;

        Instance._spawner.SpawnMobAndVegetal();
    }
}