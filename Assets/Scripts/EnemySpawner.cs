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

    public Timer timer;
    public int numberEnemySpawn = 1;
    public float enemySpawnRateIncrease = 1.005f;
    public int countTimeSpawn = 1;
    public float distanceBetweenObjects = 3;
    public int percentRandomBoss = 19;
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
    }

    private void Update()
    {
        if (timer.Finished)
        {
            int percentRandomEnemy = (100 - percentRandomBoss) / 3;
            for (int i = 0; i < numberEnemySpawn; i++)
            {
                int[] probabilities = new int[] { percentRandomEnemy, percentRandomEnemy, percentRandomEnemy, percentRandomBoss };
                GameObject randomPrefab = RandomWithProbability(enemyPrefabs, probabilities);
                //int randomPrefabID = UnityEngine.Random.Range(0, enemyPrefabs.Count);
                int randomSpawnPoint = UnityEngine.Random.Range(0, pointSpawn.Count);
                Vector3 posSpawn = pointSpawn[randomSpawnPoint].position + i * distanceBetweenObjects * transform.right;
                Instantiate(randomPrefab, posSpawn, Quaternion.identity);
            }
            if (percentRandomBoss < 99)
            {
                percentRandomBoss += 2;
            }
            countTimeSpawn++;
            numberEnemySpawn = (int)Math.Ceiling(numberEnemySpawn * Mathf.Pow(enemySpawnRateIncrease, countTimeSpawn / 5));
            timer.Duration = spawnInterval;
            timer.run();
        }
    }
    GameObject RandomWithProbability(List<GameObject> values, int[] probabilities)
    {
        int sumOfProbabilities = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            sumOfProbabilities += probabilities[i];
        }
        int randomValue = UnityEngine.Random.Range(1, sumOfProbabilities + 1);

        int currentProbability = 0;
        for (int i = 0; i < values.Count; i++)
        {
            currentProbability += probabilities[i];
            if (randomValue <= currentProbability)
            {
                return values[i];
            }
        }

        return values[values.Count - 1];
    }
}