using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy attributes")]    
    [Space(5), Header("Visuals and differentiation")]
    [Tooltip("The name for this type of enemy, it will be used to name the correspondig GameObjects according to this string.")]
    public string enemyType;
    [Tooltip("The sprite that is going to be used for this type of tower.")]
    public Sprite enemySprite;
    [Tooltip("Type of bullet used by this type of enemy.")]
    public BulletData enemyBullet;

    [Space(5), Header("Enemy related attributes")]
    [Space(2), Header("Performance attributes")]
    [Tooltip("The amount of health for a single enemy of this type.")]
    public float enemyHealth;
    [Tooltip("The movement speed for this type of enemy.")]
    public float enemySpeed;
    [Space(2), Header("Offense attributes")]
    [Tooltip("The radious used by the enemy to detect and attack nearby enemies.")]
    public float enemyDetectionRange;
    [Tooltip("The amount of damage done by the enemy's attacks.")]
    public float enemyDamage;
    [Tooltip("The amount of bullets available for the enemy to shoot.")]
    public int bulletCapacity;
    [Tooltip("The rate at which the enemy's attacks will be shot.")]
    public float enemyFireRate;
}
