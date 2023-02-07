using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Configuration.Assemblies;

public class HordeManager : MonoBehaviour
{
    public List<GameObject> hordePrefabs; // Lista de prefabs de inimigos para cada horda
    public List<int> hordeEnemies; // Lista de números de inimigos para cada horda

    private int currentHorde = 0; // Índice da horda atual
    private bool hordeActive; // Variável para verificar se a horda está ativa
    public Transform spawnPoint; // Transform do spawn point

    void Start()
    {
        StartHorde(); // Inicia a primeira horda ao iniciar o jogo
    }
    void Update()
    {
        // Verifica se a horda está ativa
        if (hordeActive)
        {
            int enemiesAlive = 0;

            // Conta o número de inimigos vivos
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponent<EnemyLife>().isAlive)
                {
                    enemiesAlive++;
                }
            }

            // Verifica se todos os inimigos foram derrotados
            if (enemiesAlive == 0)
            {
                hordeActive = false;
                currentHorde++;

                // Verifica se ainda há hordas restantes
                if (currentHorde < hordePrefabs.Count)
                {
                    StartHorde();
                }
            }
        }
    }

    void StartHorde()
    {
        hordeActive = true;

        // Instancia a horda atual no spawn point
        for (int i = 0; i < hordeEnemies[currentHorde]; i++)
        {
            Instantiate(hordePrefabs[currentHorde], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
