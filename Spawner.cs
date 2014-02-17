using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject boss;
    public GameObject player;

    public Action<int, int> WaveSpawned;
    public Action<int> EnemyCountDecreased;

    public float spawnOffset = 3;
    public float SpawnDelay = 5;

    public int enemyCountIncrement;

    int currentEnemyCount;

    int currentWaveNumber = 0;

    Vector3 randomSpawnPoint
    {
        get
        {
            int randIndex = UnityEngine.Random.Range(0, transform.childCount);
            var randPoint = UnityEngine.Random.insideUnitSphere * spawnOffset;

            randPoint.y = 0;

            var position = transform.GetChild(randIndex).position + randPoint;
            return position;
        }
    }

    void Update()
    {
        if(currentWaveNumber < 5)
            CheckIfReadySpawn();
    }

    private void CheckIfReadySpawn()
    {
        if (currentEnemyCount <= 0)
        {
            currentWaveNumber++;
            if (currentWaveNumber != 5)
            {
                currentEnemyCount = currentWaveNumber * enemyCountIncrement;
            }
            else
            {
                currentEnemyCount = 1;
            }
            
            Invoke("Spawn", SpawnDelay);
        }
    }

    void Start()
    {
        CheckIfReadySpawn();
    }

    private void Spawn()
    {
        if (WaveSpawned != null)
            WaveSpawned(currentWaveNumber, currentEnemyCount);

        for (int i = 0; i < currentEnemyCount; i++)
        {
            GameObject foe = enemy;
            if (currentWaveNumber == 5)
                foe = boss;

            var enemyGameObject = (GameObject)Instantiate(foe, randomSpawnPoint, Quaternion.identity);

            var hitDamage = enemyGameObject.GetComponent<HitDamage>();

            hitDamage.hasDied = EnemyHasDied;
            SetAITarget(enemyGameObject);
        }
    }

    void EnemyHasDied()
    {
        currentEnemyCount--;

        if (EnemyCountDecreased != null)
            EnemyCountDecreased(currentEnemyCount);
    }

    private void SetAITarget(GameObject enemyGameObject)
    {
        var ai = enemyGameObject.GetComponent<AIFollow>();
        ai.target = player.transform;
    }
}