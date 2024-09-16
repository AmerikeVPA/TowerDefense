using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EnemyManager enemyManager;

    public UnityEvent GameOver;
    
    public void Awake()
    {
        instance = this;
        StartCoroutine(StartGame());
    }
    public void EndGame(bool gameWon)
    {
        if (gameWon) 
        { 
            print("Game Won");
            return;
        }
        print("Game Lost");
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2.5f);
        enemyManager.CommenceWave();
    }
}
