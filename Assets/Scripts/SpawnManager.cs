using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    float spawnRangeValue = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    public float enemySpeed = 200;
    private bool bossSpawned = false;

    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0 && !bossSpawned)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }

        if (waveNumber == 3 && !bossSpawned)
        {
            bossSpawned = true;
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        var bossPrefab = enemyPrefab[2];
        Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        StartCoroutine(SpawnBossMinions());
    }

    IEnumerator SpawnBossMinions()
    {
        yield return new WaitForSeconds(5);
        SpawnEnemyWave(5);
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        enemySpeed += 100;
    for(int i = 0; i< enemiesToSpawn; i++)
    {
        var enemyToSpawn = Random.Range(0, 2);
        var enemy = enemyPrefab[enemyToSpawn];
        Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
    }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeValue, spawnRangeValue);
        float spawnPosZ = Random.Range(-spawnRangeValue, spawnRangeValue);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
