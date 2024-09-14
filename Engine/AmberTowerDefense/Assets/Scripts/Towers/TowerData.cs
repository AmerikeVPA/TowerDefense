using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Data")]
public class TowerData : ScriptableObject
{
    [Header("Tower attributes")]
    public string towerType;
    public float towerHealth, towerDamage, towerFireRate;
    public Sprite towerSprite;


}
