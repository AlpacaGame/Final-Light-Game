using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static bool StartEnemySpawn = false;
    public GameObject enemy;
    public Vector3 spawnPoint;
    public static int EnemyLeft = 7;
    public bool isSwitchBGM = false;

    void Update()
    {
        if(StartEnemySpawn)
        {
            Invoke("EnemySpawn", 15);
            Invoke("EnemySpawn", 20);
            Invoke("EnemySpawn", 25);
            Invoke("EnemySpawn", 30);
            StartEnemySpawn = false;
        }

        if(EnemyLeft <= 0 && !isSwitchBGM)
        {
            SoundManager.instance.Background_SourceMusic();
            Debug.Log("swichBGM");
            isSwitchBGM = true;
        }
    }

    public void EnemySpawn()
    {
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
