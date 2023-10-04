using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Atributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLefToSpawn;
    private bool isSpawning = false;

    [SerializeField] private PathFinder pathFinder;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWaves());
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLefToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLefToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLefToSpawn == 0) 
        {
            EndWave();
        }

    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
     
    private IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLefToSpawn = EnemiesPerWave();
    }
    
    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWaves());
    }

    private void SpawnEnemy() 
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        GameObject instantiatedEnemy = Instantiate(prefabToSpawn, pathFinder.startPoint.position, Quaternion.identity);
        instantiatedEnemy.GetComponent<EnemyMovement>().SetPathFinderInstance(pathFinder);
    }


    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}

