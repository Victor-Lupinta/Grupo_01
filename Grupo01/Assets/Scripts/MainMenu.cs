using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string starScene;
    
    public void StarGame()
    {
        SceneManager.LoadScene(starScene);
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
