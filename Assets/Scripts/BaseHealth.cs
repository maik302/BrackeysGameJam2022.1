using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour
{
    [SerializeField] private int _healthPoints;

    public void Hit(int hitDamage)
    {
        _healthPoints -= hitDamage;
        
        if (_healthPoints <= 0)
        {
            Die();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public abstract void Die();
}
