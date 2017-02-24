using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIController : MonoBehaviour
{
    public void StartButtonPress()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void MainMenuButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void ExitButtonPress()
    {
        Application.Quit();
    }
}

