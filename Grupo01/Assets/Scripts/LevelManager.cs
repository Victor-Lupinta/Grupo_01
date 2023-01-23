using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int goldCollected;
    public float timeInLevel;

    public string levelToLoad;

    private void Awake()
    {
        instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime; 
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+.2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gold"))
        {
            if(goldCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gold", goldCollected))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gold", goldCollected);
            }
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
                
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
