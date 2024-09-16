using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _lifetime, _speed;
    [HideInInspector]
    public float _bulletDamage;
    private Vector3 _startPosition, _direction;
    private CircleCollider2D _circleCollider;
    private Rigidbody2D _rb2D;

    #region ObjectSetup
    public void SetBullet(BulletData bulletData, float damage)
    {
        _lifetime = bulletData.bulletLifetime;
        _speed = bulletData.bulletSpeed;
        _bulletDamage = damage;
        GetComponent<SpriteRenderer>().sprite = bulletData.bulletSprite;
        _circleCollider = gameObject.AddComponent<CircleCollider2D>();
        _circleCollider.isTrigger = true;
        _rb2D = GetComponent<Rigidbody2D>();
    }
    #endregion
    public void ShootBullet(Vector3 start, Vector3 end)
    {
        _startPosition = start;
        _direction = (end - start).normalized;
        transform.position = _startPosition;
        _rb2D.velocity = _direction * _speed;
        StartCoroutine(StopBullet());
    }
    private IEnumerator StopBullet()
    {
        yield return new WaitForSeconds(_lifetime);
        TurnBulletOff();
    }
    public void TurnBulletOff()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HealthController>() != null && collision.CompareTag(GetComponentInParent<Gun>()._targetTag))
        {
            collision.GetComponent<HealthController>().TakeDamage(_bulletDamage);
            //TurnBulletOff();
        }
    }
}
