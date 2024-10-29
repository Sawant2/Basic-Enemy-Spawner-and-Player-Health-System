using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int enemyCount = 5;
    //[SerializeField] private float minSpeed = 1f;
    //[SerializeField] private float maxSpeed = 5f;

    private int currEnemyCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Spawner();
                yield return new WaitForSeconds(Random.Range(0.5f,spawnInterval));
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Spawner()
    {
        Camera cam = Camera.main;
        
        float randomX = Random.Range(0, Screen.width);
        float randomY = Screen.height;
        Vector3 randomPos = new Vector3(randomX, randomY, 10f);
        
        Vector3 spawnPos = cam.ScreenToWorldPoint(randomPos);
        //float speed = Random.Range(minSpeed, maxSpeed);
        
        GameObject enemyprefab = enemies[Random.Range(0, enemies.Count)];
        GameObject enemy = Instantiate(enemyprefab, spawnPos, Quaternion.identity);
        currEnemyCount++;
        UpdateScore.Instance.UpdateEnemyCount(currEnemyCount);
        enemy.GetComponent<Enemy>().OnEnemyDestroyed += HandleEnemyDestroyed;
        //enemy.GetComponent<Enemy>().SetSpeed(speed);
    }

    private void HandleEnemyDestroyed()
    {
        currEnemyCount--;
        UpdateScore.Instance.UpdateEnemyCount(currEnemyCount);
    }
}