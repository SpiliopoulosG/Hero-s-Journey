using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    public static bool gameIsPaused;

    void showMenu() {
        mainMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void handleMenuClick() {
        togglePause();
    }

    void togglePause() {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused) {
            showMenu();
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
            mainMenuUI.SetActive(false);
        }
    }

    void Start() {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }
    }
}
