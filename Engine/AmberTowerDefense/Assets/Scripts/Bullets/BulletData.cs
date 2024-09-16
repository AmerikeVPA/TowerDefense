using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object Data/Bullet Data")]
public class BulletData : ScriptableObject
{
    /*
     * These scripts keep the information for the different kinds of enemies, towers or bullets.
     * They are designed in a way where any team member can modify the attributes directly from the engine without having to open any code editor.
     * Additionally it contains labels that will explain the different variables through the editor in case the information is needed by the user.
     */
    [Header("Bullet attributes")]

    [Space(5), Header("Visuals and differentiation")]
    [Tooltip("The name for this type of bullet, it will be used to name the corresponding GameObjects according to this string.")]
    public string bulletType;
    [Tooltip("The sprite that is going to be used for this type of bullet.")]
    public Sprite bulletSprite;

    [Space(5), Header("Movement related attributes")]
    [Tooltip("The time this type of bullet can be active in scene after being shot.")]
    public float bulletLifetime;
    [Tooltip("The speed at which this type of bullet will move through the scene.")]
    public float bulletSpeed;
}
