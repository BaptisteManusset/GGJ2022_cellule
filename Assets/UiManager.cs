using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    [SerializeField] private HealthManager _playerHealth;

    [SerializeField] private Image healthBar;
    [Space, SerializeField] private GameObject gameOver;

    [Space, SerializeField] private TMP_Text score;

    private void Start() {
        _playerHealth = Player.Instance._healthManager;
        // _playerHealth.OnHealthChange += PlayerHealthChange;
        // _playerHealth.OnDead += PlayerHealthChange;
        _playerHealth.OnDead += () => { gameOver.SetActive(true); };


        gameOver.SetActive(false);
    }

    private void FixedUpdate() {
        healthBar.fillAmount = _playerHealth.GetHealth() / _playerHealth.maxHealth;

        score.text = $"{Manager.Instance.Score} DNA";
    }
}