using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach(WaveConfigSO currentWave in waveConfigs)
        {
            for (int i = 0; i < currentWave.GetEnemyCount(); ++i)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWayPoint().position,
                    Quaternion.identity
                );

                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
    }
}
