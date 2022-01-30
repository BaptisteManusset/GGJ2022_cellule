using UnityEngine;

public class Manager : MonoBehaviour {
    public static Manager Instance;

    private Spawner _spawner;

    public bool gameOver = false;

    public int Score = 0;

    private void Awake() {
        Player.Instance._healthManager.OnDead += GameOver;

        _spawner = GetComponent<Spawner>();
        Instance = this;
        Score = 0;
        Time.timeScale = 1;

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