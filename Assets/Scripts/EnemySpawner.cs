using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 3f;
    public int enemyCount = 0;
    static public bool gameStart = true;//to be moved and modified when i have the begining UI done

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitforStart());
        if (gameStart)
            StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(1);
        while (enemyCount < 1)
        {
            SpawnEnemy();
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }// while the enemy count is under 4 , spawns an enemy randomly on the map and waits for an interval betwen .5 and 3 seconds

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 0.2f, Random.Range(-10f, 10f));
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        enemyCount++;
    }//spawns enemy randomly
    IEnumerator WaitforStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("start spawning enemies");
    }
}
