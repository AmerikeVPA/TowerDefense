using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawnTimer;
    public GameObject enemyPrefab;
    public int smallEnemyQty, mediumEnemyQty, bigEnemyQty;
    public EnemyData smallEnemyData, mediumEnemyData, bigEnemyData;

    private int _totalEnemies;

    private void Awake()
    {
        _totalEnemies = smallEnemyQty + mediumEnemyQty + bigEnemyQty;
    }
    public void CommenceWave()
    {
        StartCoroutine(SpawnEnemies(smallEnemyQty, smallEnemyData));
        StartCoroutine(SpawnEnemies(mediumEnemyQty, mediumEnemyData));
        StartCoroutine(SpawnEnemies(bigEnemyQty, bigEnemyData));
    }
    private IEnumerator SpawnEnemies(int amount, EnemyData enemyToSpawn)
    {
        GameObject enemyHolder = new GameObject($"{enemyToSpawn.enemyType} Holder");
        enemyHolder.transform.parent = transform;
        for(int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, enemyHolder.transform);
            newEnemy.GetComponent<Enemy>().SetEnemy(enemyToSpawn);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    public void EnemyDestroyed()
    {
        _totalEnemies--;
        if (_totalEnemies <= 0)
        {
            GameManager.instance.EndGame(true);
        }
    }
}
