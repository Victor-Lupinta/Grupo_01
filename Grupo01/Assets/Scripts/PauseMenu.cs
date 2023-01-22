using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public string LevelSelect, mainMenu;

    public GameObject pauseScreen;
    public bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        instance= this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Menu"))
        {
            pauseUnpause();
        }
    }

    public void pauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        
        } else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void levelSelect()
    {
        SceneManager.LoadScene(LevelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    

}
