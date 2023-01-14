using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string startScene;

    public void StarGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  
}
