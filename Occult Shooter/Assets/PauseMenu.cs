using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject fpsCam;

    void Start() {
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
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
}
