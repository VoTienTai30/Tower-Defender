
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField]
//    public List<GameObject> enemyPrefabs;

//    [SerializeField]
//    public List<Transform> pointSpawn;

//    [SerializeField]
//    public float spawnInterval = 2f;

//    public static EnemySpawner instance;

//    private void Awake()
//    {
//        instance = this;
//    }

//    public void Spawning()
//    {
//        StartCoroutine(SpawnDelay());
//    }

//    IEnumerator SpawnDelay()
//    {
//        SpawnEnemy();

//        yield return new WaitForSeconds(spawnInterval);

//        StartCoroutine(SpawnDelay());
//    }

//    void SpawnEnemy()
//    {
//        int randomPrefabID = Random.Range(0, enemyPrefabs.Count);
//        int randomSpawnPoint = Random.Range(0, pointSpawn.Count);
//        GameObject enemySpawned = Instantiate(enemyPrefabs[randomPrefabID], pointSpawn[randomSpawnPoint]); 

//    }


//}
