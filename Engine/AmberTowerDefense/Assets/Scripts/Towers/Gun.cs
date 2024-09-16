using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*
     * This class is responsible of attacking a defined target by its parent object.
     * It receives the information and sets the variables so they can interact with the scene accordingly.
     */

    private bool _targetInRange = false, _canShoot = true;
    private int _maxBullets;
    private float _damage, _fireRate;
    [HideInInspector]
    public string _targetTag, _bulletTag;
    private Vector3 _targetToShoot;
    private CircleCollider2D _detectionZone;
    private BulletData _ammoType;
    private Queue<Bullet> _bulletAvailable = new Queue<Bullet>();
    public void SetGunAttributes(BulletData ammoData, int maxBullets, float gunRange, float gunDamage, float fireRate)
    {
        _ammoType = ammoData;
        _maxBullets = maxBullets;
        _damage = gunDamage;
        _fireRate = fireRate;

        _detectionZone = gameObject.AddComponent<CircleCollider2D>();
        _detectionZone.radius = gunRange;
        _detectionZone.isTrigger = true;
        
        SetBulletPool();
    }
    private void SetBulletPool()
    {
        for (int i = 0; i < _maxBullets; i++)
        {
            GameObject newBullet = new GameObject($"{_ammoType.bulletType}_0{i}", typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Bullet));
            newBullet.tag = _bulletTag;
            newBullet.transform.parent = transform;
            newBullet.transform.position = transform.position;
            newBullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            newBullet.GetComponent<Rigidbody2D>().freezeRotation = true;
            newBullet.GetComponent<Bullet>().SetBullet(_ammoType, _damage);
            _bulletAvailable.Enqueue(newBullet.GetComponent<Bullet>());
            newBullet.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_targetTag))
        {
            _targetToShoot = collision.transform.position;
            _targetInRange = true;
        }
        else { _targetInRange = false; }
    }
    private void Update()
    {
        ShootAtTarget();
    }
    private void ShootAtTarget()
    {
        if (_targetInRange && _canShoot)
        {
            _canShoot = false;
            Bullet nextBullet = _bulletAvailable.Dequeue();
            nextBullet.gameObject.SetActive(true);
            nextBullet.ShootBullet(transform.position, _targetToShoot);
            _bulletAvailable.Enqueue(nextBullet);
            StartCoroutine(FireCooldown());
        }
    }
    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(_fireRate);
        _canShoot = true;
    }
}
