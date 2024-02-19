using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
     WaveConfigSO currentWave;
     [SerializeField] float timeBetweenEnemyWaves = 0f;
     [SerializeField] bool isLooping = true;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
    do {
        foreach(WaveConfigSO wave in waveConfigs){
        currentWave = wave;    
        for(int i = 0; i < currentWave.GetEnemyCount(); i++){
        Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, 
        Quaternion.Euler(0,0,180), transform );

        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenEnemyWaves);
        }

    }
    while(isLooping);
       

        
       
    }
    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }
}
