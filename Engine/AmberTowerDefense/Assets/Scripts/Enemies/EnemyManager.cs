using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /*
     * This manager is responsible of spawning the enemies throughout the game.
     * To spawn the enemies it takes the EnemyData and the amount of enemies to be spawned
     * and creates instances of these enemies with their corresponding information.
     * 
     * It also counts the total amount of enemies that are requiered to be destroyed in order to win the game.
     * In case of destroying all the enemies, it sends the signal to the GameManager to end the game as a player victory.
     */
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
