using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval = 1f;
    public int minGroup = 3;
    public int maxGroup = 5;
    private EnemyPool enemyPool;
    // Start is called before the first frame update
    void Start()
    {

        enemyPool = EnemyPool.Instance;
        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine() {
        while(true) {
            SpawnEnemyGroup();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyGroup() {
         Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Tentukan jumlah musuh yang akan di-spawn secara acak
        int enemyCount = Random.Range(minGroup, maxGroup + 1);

        // Spawn musuh sesuai jumlah yang diinginkan
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = enemyPool.GetEnemyFromPool();
            Vector2 spawnPosition = new Vector2(spawnPoint.position.x, Random.Range(spawnPoint.position.y, spawnPoint.position.y - 5));
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);  // Aktifkan musuh dari pool
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
