using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 spawnPoint;
    public static int EnemyLeft;
    [SerializeField] private int showEnemyLeft;
    public bool isSwitchBGM = false;

    void Start()
    {
        EnemyLeft = 0;
        isSwitchBGM = false;
    }

    void Update()
    {
        showEnemyLeft = EnemyLeft;

        if (EnemyLeft <= 0 && !isSwitchBGM)
        {
            SoundManager.instance.Background_SourceMusic();
            Debug.Log("swichBGM");
            isSwitchBGM = true;
        }
    }

    public void InvokeEnemySpawn(float time)
    {
        Invoke("EnemySpawn", time);
    }

    public void EnemySpawn()
    {
        Instantiate(enemy, spawnPoint, Quaternion.identity);
        EnemyLeft += 1;
    }
}
