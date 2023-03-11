using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    private void Start()
    {
        StartCoroutine(WaveStartDelay());    
    }

    IEnumerator WaveStartDelay() { 
        yield return new WaitForSeconds(2);

        GetComponent<EnemySpawner>().Spawning();
    }
}
