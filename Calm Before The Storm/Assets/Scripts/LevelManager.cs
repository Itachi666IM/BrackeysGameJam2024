using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject pauseCanvas;

    private bool isPaused = false;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();    
    }
    public void Resume()
    {
        playerMovement.canMove = true;
        pauseCanvas.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.canMove = false;
            if(!isPaused)
            {
                isPaused = true;
                pauseCanvas.SetActive(true);
            }
            else
            {
                isPaused = false;
                Resume();
            }
        }
    }
}
