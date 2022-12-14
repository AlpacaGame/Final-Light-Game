using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static bool StartEnemySpawn = false;
    public GameObject enemy;
    public Vector3 spawnPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if(StartEnemySpawn)
        {
            Invoke("EnemySpawn", 10);
            Invoke("EnemySpawn", 15);
            Invoke("EnemySpawn", 20);
            StartEnemySpawn = false;
        }
    }

    public void EnemySpawn()
    {
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
