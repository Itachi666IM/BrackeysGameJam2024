using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject rulesPanel;
    [SerializeField] GameObject mainMenuPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ViewRules()
    {
        rulesPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        mainMenuPanel.SetActive(true);
        rulesPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
