using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private float _speed;
    private Tower _targetTower;
    private CircleCollider2D _persuitTargetRange;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2D;
    private Gun _weapon;
    private HealthController _healthController;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _persuitTargetRange = GetComponent<CircleCollider2D>();
    }
    #region ObjectSetup
    public void SetEnemy(EnemyData dataToUse)
    {
        string bulletTag = "EnemyBullet";

        _spriteRenderer.sprite = dataToUse.enemySprite;
        transform.AddComponent<BoxCollider2D>();
        gameObject.name = dataToUse.enemyType;
        
        _speed = dataToUse.enemySpeed;

        _healthController = gameObject.AddComponent<HealthController>();
        _healthController._health = dataToUse.enemyHealth;
        _healthController._onHealthDepleted.AddListener(DestroyEnemy);

        CreateGun(dataToUse.enemyType);
        _weapon._bulletTag = bulletTag;
        _weapon.SetGunAttributes(dataToUse.enemyBullet, dataToUse.bulletCapacity, dataToUse.enemyDetectionRange, dataToUse.enemyDamage, dataToUse.enemyFireRate);
        _weapon._targetTag = "Tower";
    }    
    private void CreateGun(string enemyName)
    {
        GameObject enemyGun = new GameObject($"{enemyName} Weapon");
        enemyGun.transform.parent = transform;
        enemyGun.transform.position = transform.position;
        _weapon = enemyGun.AddComponent<Gun>();
    }
    #endregion
    private void Update()
    {
        MoveEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            _targetTower = collision.GetComponent<Tower>();
        }
    }
    private void MoveEnemy()
    {
        float movementSpeed;
        Vector3 directionToFollow;
        if(_targetTower != null)
        {
            directionToFollow = (_targetTower.transform.position - transform.position).normalized;
            movementSpeed = (Vector3.Distance(transform.position, _targetTower.transform.position) > (_persuitTargetRange.radius/2)) ? _speed : 0;
        }
        else
        {
            directionToFollow = Vector3.left;
            movementSpeed = _speed;
        }
        _rb2D.velocity = directionToFollow * movementSpeed;
    }
    public void DestroyEnemy()
    {
        transform.parent.parent.GetComponent<EnemyManager>().EnemyDestroyed();
        Destroy(gameObject);
    }
}
