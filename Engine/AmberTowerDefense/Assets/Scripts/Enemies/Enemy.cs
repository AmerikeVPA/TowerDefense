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
    /*
     * This script doesn't need any input from the inspector as it recieves the data from the EnemyManager.
     * It creates the necessary components accordingly to the informations of the respective enemy type given by the manager.
     */
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

    /*
     * This section uses the data from the scriptable objecto to create any necessary componets
     * for the optimal functioning of the object.
     */
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

    /*
     * This section is responsible of moving the enemy to the target and other scene interactions.
     */
    #region EnemyActions
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
    #endregion
}
