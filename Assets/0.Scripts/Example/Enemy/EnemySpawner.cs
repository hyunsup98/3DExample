using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Collider col;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 2f;

    private float spawnTime;
    private float spawnTimer;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnTime)
        {
            spawnTimer = 0;
            GetSpawnTime();
            SpawnEnemy();
        }
    }

    private void Init()
    {
        if (col == null)
            col = GetComponent<Collider>();

        if(minSpawnTime > maxSpawnTime)
        {
            float temp = minSpawnTime;
            minSpawnTime = maxSpawnTime;
            maxSpawnTime = temp;
        }

        spawnTimer = 0;
        GetSpawnTime();
    }

    private void GetSpawnTime()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Debug.Log(spawnTime);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = GetRandomPos();
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, transform.rotation);
    }

    private Vector3 GetRandomPos()
    {
        Vector3 pos = col.transform.position;

        Vector3 colVec = col.bounds.extents;

        colVec.x = Random.Range(-colVec.x, colVec.x);
        colVec.z = Random.Range(-colVec.z, colVec.z);

        return pos + colVec;
    }
}
