using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int totalScene = SceneManager.sceneCountInBuildSettings;
        Debug.Log("Количество сцен: " + totalScene);

        if (currentScene < totalScene - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
