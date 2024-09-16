using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    /*
     * This manager keeps track of the amount of active towers in scene.
     * When a Tower gets destroyed by the enemies it will tell this manager to reduce the active tower count.
     * If the count reaches 0 it will tell the GameManager that the game was lost and end the game.
     */
    public static TowerManager instance;

    private int activeTowersCount;

    private void Awake()
    {
        instance = this;
        activeTowersCount = CountTotalTowers();
    }
    private int CountTotalTowers()
    {
        int towersInLevel = 0;
        foreach(Transform towerChild in transform)
        {
            towersInLevel++;
        }
        return towersInLevel;
    }
    public void TowerDestroyed()
    {
        activeTowersCount--;
        if (activeTowersCount <= 0)
        {
            GameManager.instance.EndGame(false);
        }
    }
}
