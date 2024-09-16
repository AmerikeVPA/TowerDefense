using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
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
