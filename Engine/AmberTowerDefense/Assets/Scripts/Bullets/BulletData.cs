using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object Data/Bullet Data")]
public class BulletData : ScriptableObject
{
    public string bulletType;
    public Sprite bulletSprite;

    public float bulletLifetime, bulletSpeed;
}
