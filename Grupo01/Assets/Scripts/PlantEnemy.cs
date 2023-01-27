using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;

    public float waitTimeToAttack = 3;

    public Animator anim;

    public GameObject bulletPrefab;

    public Transform launchSpawPoint;

    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            anim.Play("attack");
            Invoke("LauchBullet", 0.5f);
                
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bulletPrefab, launchSpawPoint.position, launchSpawPoint.rotation);
    }
}
