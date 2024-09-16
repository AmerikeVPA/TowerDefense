using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    /*
     * This code works as a component in health dependent objects like the towers, enemies, or potential defending units.
     * 
     * These objects will add the component through code and will set the amount of health corresponding to their respective scriptiable object.
     * 
     * Additionally the object that adds this component will determine which function will be executed when the health is depleted.
     * 
     * When a bullet hits the object it sends the signal to this script to reduce the health and in case the health is depleted the event is called.
     */

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
