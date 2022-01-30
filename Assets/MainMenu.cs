using UnityEngine;

public class MainMenu : MonoBehaviour {
    private void Awake() {
        Time.timeScale = 0;
        Manager.Instance.mainMenu = true;

    }

    public void Play() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Manager.Instance.mainMenu = false;

    }
}