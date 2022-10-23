using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRangeValue = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeValue, spawnRangeValue);
        float spawnPosZ = Random.Range(-spawnRangeValue, spawnRangeValue);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}