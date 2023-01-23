using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;


    public string levelToLoad, levelToCheck, levelName;

    public int goldCollected, totalGold;
    public float bestTime, targetTime;

    public GameObject goldBadge, timeBadge;

    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToLoad + "_gold"))
            {
                goldCollected = PlayerPrefs.GetInt(levelToLoad + "_gold");
            }
            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if (goldCollected >= totalGold && totalGold !=0)
            {
                goldBadge.SetActive(true);
            }
            if (bestTime <= targetTime && bestTime !=0)
            {
                timeBadge.SetActive(true);
            }

            isLocked  = true;
            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }

            if (levelToLoad == levelToCheck)
            {
                isLocked= false;
            }
        }
    }

    
    void Update()
    {
        
    }
}
