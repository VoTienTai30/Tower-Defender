using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> enemyPrefabs;

    [SerializeField]
    public List<Transform> pointSpawn;

    [SerializeField]
    public float spawnInterval = 2f;

    public static EnemySpawner instance;

    private Timer timer;
    private int numberEnemySpawn = 1;
    private float enemySpawnRateIncrease = 1.005f;
    private int countTimeSpawn = 1;
    private float distanceBetweenObjects = 3;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numberEnemySpawn = (int)Math.Ceiling(numberEnemySpawn * Mathf.Pow(enemySpawnRateIncrease, countTimeSpawn));
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = spawnInterval;
        timer.run();
        int randomPrefabID = UnityEngine.Random.Range(0, enemyPrefabs.Count);
        int randomSpawnPoint = UnityEngine.Random.Range(0, pointSpawn.Count);
        Instantiate(enemyPrefabs[randomPrefabID], pointSpawn[randomSpawnPoint]);
        Debug.Log(numberEnemySpawn);
    }

    private void Update()
    {
        if (timer.Finished)
        {
            for (int i = 0; i < numberEnemySpawn; i++)
            {
                int randomPrefabID = UnityEngine.Random.Range(0, enemyPrefabs.Count);
                int randomSpawnPoint = UnityEngine.Random.Range(0, pointSpawn.Count);
                Vector3 posSpawn = pointSpawn[randomSpawnPoint].position + i * distanceBetweenObjects * transform.right;
                Instantiate(enemyPrefabs[randomPrefabID], posSpawn, Quaternion.identity);
            }
            countTimeSpawn++;
            numberEnemySpawn = (int)Math.Ceiling(numberEnemySpawn * Mathf.Pow(enemySpawnRateIncrease, countTimeSpawn / 5));
            timer.Duration = spawnInterval;
            timer.run();
            Debug.Log(numberEnemySpawn);
        }
    }

}