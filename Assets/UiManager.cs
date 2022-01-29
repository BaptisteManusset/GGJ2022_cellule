using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    [SerializeField] private HealthManager _playerHealth;

    [SerializeField] private Image healthBar;
    [Space, SerializeField] private GameObject gameOver;

    private void Awake() {
        _playerHealth.OnHealthChange += PlayerHealthChange;
        _playerHealth.OnDead += PlayerHealthChange;
        _playerHealth.OnDead += () => { gameOver.SetActive(true); };


        gameOver.SetActive(false);
    }

    private void PlayerHealthChange() {
        healthBar.fillAmount = _playerHealth.GetHealth() / _playerHealth.maxHealth;
    }
}