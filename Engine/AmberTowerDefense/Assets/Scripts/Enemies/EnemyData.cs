using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy attributes")]
    public string enemyType;
    public float enemyHealth, enemySpeed, enemyDamage, enemyAttackRate;
    public Sprite enemySprite;
}
