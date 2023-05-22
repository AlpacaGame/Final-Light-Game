using System.Collections;
using UnityEngine;

public class MonsterRespawnPoint : MonoBehaviour
{
    public GameObject monsterPrefab; // 怪物的預製體
    public int maxSpawnCount = 5; // 最大生成數量
    public float spawnInterval = 10.0f; // 生成間隔

    private int spawnCount = 0; // 已生成數量

    public void StartSpawn()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (spawnCount < maxSpawnCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            // 生成怪物
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            spawnCount++;
        }
    }
}