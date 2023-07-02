using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
