using System.Collections;
using UnityEngine;

public class WaveEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public int enemiesPerWave = 5; // Number of enemies to spawn per wave
    public float timeBetweenWaves = 5f; // Time between waves
    public Transform spawnPoint; // The point where enemies will spawn

    private int currentWave = 0; // Current wave number

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true) // Infinite loop for continuous waves
        {
            currentWave++;
            Debug.Log("Wave " + currentWave + " starting!");

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2f); // Delay between enemy spawns
            }

            yield return new WaitForSeconds(timeBetweenWaves); // Delay before the next wave
        }
    }

    private void SpawnEnemy()
    {
        // Instantiate the enemy at the spawn point
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Enemy spawned!");
    }
}
