using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadSceneAsync(scene_name);
    }

    public void open_map(int index)
    {
        var name = $"map_{index}";
        SceneManager.LoadScene(name);
    }

    public void unlock_new_map()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("unlock"))
        {
            PlayerPrefs.SetInt("unlock", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("unlocked_map", PlayerPrefs.GetInt("unlocked_map", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void rest_map()
    {
        PlayerPrefs.DeleteAll();
    }
}
