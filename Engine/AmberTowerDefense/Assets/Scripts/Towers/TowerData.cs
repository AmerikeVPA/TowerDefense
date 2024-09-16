using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object Data/Tower Data")]
public class TowerData : ScriptableObject
{
    /*
     * These scripts keep the information for the different kinds of enemies, towers or bullets.
     * They are designed in a way where any team member can modify the attributes directly from the engine without having to open any code editor.
     * Additionally it contains labels that will explain the different variables through the editor in case the information is needed by the user.
     */

    [Header("Tower attributes")]
    
    [Space(5), Header("Visuals and differentiation")]
    [Tooltip("The name for this type of tower, it will be used to name the corresponding GameObjects according to this string.")]
    public string towerType;
    [Tooltip("The sprite that is going to be used for this type of tower.")]
    public Sprite towerSprite;
    [Tooltip("Type of bullet used by this type of tower.")]
    public BulletData towerBullet;

    [Space(5), Header("Tower related attributes")]
    [Space(2), Header("Defense attributes")]
    [Tooltip("The amount of health for a single tower of this type.")]
    public float towerHealth;
    [Tooltip("The radious used by the tower to detect and attack nearby enemies.")]
    public float towerSentryRange;
    [Space(2), Header("Offense attributes")]
    [Tooltip("The amount of damage done by the tower's defending attacks.")]
    public float towerDamage;
    [Tooltip("The amount of bullets available for the tower to shoot.")]
    public int bulletCapacity;
    [Tooltip("The rate at which the tower's attacks will be shot.")]
    public float towerFireRate;

    [Space(5), Header("Gameplay related attributes")]
    [Tooltip("The radious where the player will be able to place defending units.")]
    public float defendantPlacementRange;
}
