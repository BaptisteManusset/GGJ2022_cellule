using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject menu;
    private void Awake() {
        Time.timeScale = 0;
        Manager.Instance.mainMenu = true;
    }

    public void Play() {
        Time.timeScale = 1;
        menu.SetActive(false);
        Manager.Instance.mainMenu = false;
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }

    private void Pause() {
        Time.timeScale = 0;
        menu.SetActive(true);

        Manager.Instance.mainMenu = true;
    }
}