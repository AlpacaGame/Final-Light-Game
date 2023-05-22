using System.Collections;
using UnityEngine;

public class MonsterRespawnPoint : MonoBehaviour
{
    public GameObject monsterPrefab; // �Ǫ����w�s��
    public int maxSpawnCount = 5; // �̤j�ͦ��ƶq
    public float spawnInterval = 10.0f; // �ͦ����j

    private int spawnCount = 0; // �w�ͦ��ƶq

    public void StartSpawn()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (spawnCount < maxSpawnCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            // �ͦ��Ǫ�
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            spawnCount++;
        }
    }
}