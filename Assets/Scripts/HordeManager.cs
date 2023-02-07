using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class HordeManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy1Prefab;
    [SerializeField] private GameObject _enemy2Prefab;
    [SerializeField] private GameObject _enemy3Prefab;

    private List<GameObject> hordePrefabs; // Lista de prefabs de inimigos para cada horda

    public List<int> hordeEnemies; // Lista de números de inimigos para cada horda
    
    public float spawnInterval = 1f; // Intervalo entre a criação de inimigos
    
    private int currentHorde = 0; // Índice da horda atual
    
    private bool hordeActive; // Variável para verificar se a horda está ativa
    
    public Transform spawnPoint; // Transform do spawn point
    
    public TMPro.TextMeshProUGUI hordeCounterText; // Texto para exibir o número da horda atual
 
    private void Awake()
    {
        hordePrefabs = new List<GameObject>();
    }

    void Start()
    {
        StartHorde(); // Inicia a primeira horda ao iniciar o jogo
    }

    void Update()
    {
        hordeCounterText.text = "Horda " + (currentHorde + 1) + " de " + hordeEnemies.Count;
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

        StartCoroutine(SpawnHorde());
    }

    IEnumerator SpawnHorde()
    {
        // Instancia a horda atual no spawn point com o intervalo definido
        GameObject prefab;
        for (int i = 0; i < hordeEnemies[currentHorde]; i++){
            if (currentHorde < 2)
            {
                prefab = _enemy1Prefab;
            }
            else if (currentHorde < 4)
            {
                prefab = Random.Range(0, 100) > 49 ? _enemy1Prefab : _enemy2Prefab;
            }
            else
            {
                prefab = Random.Range(0, 100) > 49 ? _enemy2Prefab : _enemy3Prefab;
            }
            {
                var obj = Instantiate(prefab, spawnPoint.position, quaternion.identity);
                hordePrefabs.Add(obj);
                yield return new WaitForSeconds(spawnInterval);
                
            }
        }
    }
}
