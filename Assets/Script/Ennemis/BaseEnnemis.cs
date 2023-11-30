using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnnemis : MonoBehaviour
{
    private int _health, _maxHealth = 50;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int _damageReceived)
    {
        _health -= _damageReceived;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
