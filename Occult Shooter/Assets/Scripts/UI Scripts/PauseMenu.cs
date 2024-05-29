using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public bool gameOver = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject fpsCam;

    void Start() {
        Time.timeScale = 1f;
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOver) {
            if(gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        if(gameOver) {
            gameOverUI.SetActive(true);
            fpsCam.GetComponent<CameraController>().UnlockCursor();
            Time.timeScale = 0f;            
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        fpsCam.GetComponent<CameraController>().LockCursor();
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        fpsCam.GetComponent<CameraController>().UnlockCursor();
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu() {
        Debug.Log("Loading menu...");
        
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quiting menu...");
        Application.Quit();
    }

    public void SetGameOver(bool state) {
        gameOver = state;
    }

    public void RetryGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ALEC Enemy Testing"); //TODO: Make this not hard coded!! This for testing purposes only!!
    }
}
