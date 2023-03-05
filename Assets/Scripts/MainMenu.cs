using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public string hallOfFame;
    public string mainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuScreen()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void HallOfFame()
    {
        SceneManager.LoadScene(hallOfFame);
    }
}
