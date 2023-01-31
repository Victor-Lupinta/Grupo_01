using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public string mainMenu, creditos;

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(creditos);  
    }
}
