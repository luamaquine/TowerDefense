using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Vetor de prefabs dos inimigos
    public Transform spawnPoint; // Ponto de spawn dos inimigos
    public int totalEnemies = 10; // Número total de inimigos na onda
    public float spawnInterval = 1.0f; // Intervalo de tempo entre o spawn de inimigos
    public float waveInterval = 10.0f; // Intervalo de tempo entre as ondas

    private int enemiesSpawned = 0; // Número de inimigos já spawnados
    private float lastSpawnTime; // Tempo do último spawn de inimigo

    private void Start()
    {
        // Iniciar a primeira onda imediatamente
        Invoke("StartWave", 0);
    }

    private void StartWave()
    {
        // Aumentar o número total de inimigos em cada onda
        totalEnemies += 1;
        enemiesSpawned = 0;
        lastSpawnTime = Time.time;

        // Invocar a próxima onda após o intervalo de tempo entre ondas
        Invoke("StartWave", waveInterval);
    }

    private void Update()
    {
        // Verificar se é hora de spawnar um novo inimigo
        if (enemiesSpawned < totalEnemies && Time.time - lastSpawnTime >= spawnInterval -1)
        {
            // Escolher um tipo de inimigo aleatório
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);

            // Spawnar um novo inimigo
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
            lastSpawnTime = Time.time;
        }
    }
}
