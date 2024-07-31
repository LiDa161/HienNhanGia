using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
