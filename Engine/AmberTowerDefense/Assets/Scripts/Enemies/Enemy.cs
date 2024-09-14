using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private float _health, _speed, _damage, _rate;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetTower();
    }
    private void SetTower()
    {
        _health = enemyData.enemyHealth;
        _speed = enemyData.enemySpeed;
        _damage = enemyData.enemyDamage;
        _rate = enemyData.enemyAttackRate;
        _spriteRenderer.sprite = enemyData.enemySprite;
        transform.AddComponent<BoxCollider2D>();
        gameObject.name = enemyData.enemyType;
    }
    
}
