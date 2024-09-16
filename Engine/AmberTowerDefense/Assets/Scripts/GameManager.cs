using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    /*
     * This scripts manages the flow of the game, 
     * for example sending a signal to start the enemy spawning 
     * or recieving the signal to end the game and show if the player won or lost.
     */

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
