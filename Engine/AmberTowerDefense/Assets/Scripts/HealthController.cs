using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public float _health;
    public UnityEvent _onHealthDepleted = new UnityEvent();

    public void TakeDamage(float damageTaken)
    {
        _health -= damageTaken;
        if (_health <= 0)
        {
            _onHealthDepleted.Invoke();
        }
    }
}
