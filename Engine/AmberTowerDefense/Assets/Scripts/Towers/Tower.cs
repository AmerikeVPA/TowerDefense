using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Tower : MonoBehaviour
{
    public TowerData towerData;

    private float _health;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetTower();
    }
    private void SetTower()
    {
        _health = towerData.towerHealth;
        _spriteRenderer.sprite = towerData.towerSprite;
        transform.AddComponent<BoxCollider2D>();
        gameObject.name = towerData.towerType;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
