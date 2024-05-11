using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerScript : MonoBehaviour
{
    public EnemySpawner EnemySpawner;
    public GameObject ShieldPotionprefab;
    public GameObject Meadprefab;

    public string[] Potions;
    public int Potions_value;

    void Start()
    {
        
    }

    private void Update()
    {
        if (EnemySpawner.gameStart == true)
        {
            Debug.Log("POTION SPAWNER");
            SpawnRoutine();
        }
    }

    void    SpawnRoutine()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 0.2f, Random.Range(-10f, 10f));
        Potions_value = Random.Range(0, Potions.Length);
        if (Potions_value == 1)
            Instantiate(ShieldPotionprefab, spawnPos, ShieldPotionprefab.transform.rotation);
        EnemySpawner.gameStart = false;
    }
}
