using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    [SerializeField]
    private float restartDelay = 1f;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private GameObject ui;
    [SerializeField]
    private Camera mainCamera;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            // Invoke("Restart", restartDelay);
            Time.timeScale = 0f;
            ui.SetActive(false);
            gameover.SetActive(true);
            mainCamera.GetComponent<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        mainCamera.GetComponent<CameraController>().enabled = true;
    }
}
