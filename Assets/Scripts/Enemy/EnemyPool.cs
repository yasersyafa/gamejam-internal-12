using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private List<GameObject> enemyPool; 

    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++) {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetEnemyFromPool() {
        foreach(GameObject obj in enemyPool) {
            if(!obj.activeInHierarchy) {
                return obj;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
