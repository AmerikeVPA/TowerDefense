using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Tower : MonoBehaviour
{
    /*
     * This script recieves a TowerData and molds the object accordingly to the information.
     * The only input given by the user is the data and it must be placed as a child of the 
     * TowerManager for it to be counted for the game flow.
     */

    public TowerData towerData;

    private float _unitPlacementRad;
    private SpriteRenderer _spriteRenderer;
    private Gun _sentry;
    private HealthController _healthController;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetTower();
    }

    #region ObjectSetup
    private void SetTower()
    {
        SelfIdentification();
        VariableSetup();
    }
    private void SelfIdentification()
    {
        _spriteRenderer.sprite = towerData.towerSprite;
        transform.AddComponent<BoxCollider2D>();
        gameObject.name = towerData.towerType;
    }
    private void VariableSetup()
    {
        string bulletTag = "PlayerBullet";
        _unitPlacementRad = towerData.defendantPlacementRange;

        _healthController = gameObject.AddComponent<HealthController>();
        _healthController._health = towerData.towerHealth;
        _healthController._onHealthDepleted.AddListener(DestroyTower);

        if (towerData.towerBullet == null) { return; }
        CreateGun();
        _sentry._bulletTag = bulletTag;
        _sentry.SetGunAttributes(towerData.towerBullet, towerData.bulletCapacity, towerData.towerSentryRange, towerData.towerDamage, towerData.towerFireRate);
        _sentry._targetTag = "Threat";
    }
    private void CreateGun()
    {
        GameObject towerSentry = new GameObject($"{towerData.towerType} Sentry");
        towerSentry.transform.parent = transform;
        towerSentry.transform.position = transform.position;
        _sentry = towerSentry.AddComponent<Gun>();
    }
    #endregion

    public void DestroyTower()
    {
        GetComponentInParent<TowerManager>().TowerDestroyed();
        Destroy(gameObject);
    }
}
