using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float minSpawnInterval = 0.5f;
	public float maxSpawnInterval = 3f;
	public int enemyCount = 0;
	static public bool gameStart = false;//to be moved and modified when i have the begining UI done

	// Start is called before the first frame update
	IEnumerator Start()
	{
		yield return StartCoroutine(SpawnTimer());
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(1);
		while (enemyCount < 3)
		{
			SpawnEnemy();
			float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
			yield return new WaitForSeconds(spawnInterval);
		}
		gameStart = true;
	}// while the enemy count is under 4 , spawns an enemy randomly on the map and waits for an interval betwen .5 and 3 seconds

	void SpawnEnemy()
	{
		Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 0.2f, Random.Range(-10f, 10f));
		Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
		enemyCount++;
	}//spawns enemy randomly
}
