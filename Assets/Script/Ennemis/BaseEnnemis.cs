using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseEnnemis : MonoBehaviour
{
    [SerializeField] private Transform _trBaseEnnemis;
    private int _health, _maxHealth = 50;
    private int _maxDist = 20;
    private float _speed = 1f;

    private void Start()
    {
        _trBaseEnnemis = GetComponent<Transform>();
        _health = _maxHealth;
    }

    private void Update()
    {
        Movement();
    }
    public void TakeDamage(int _damageReceived)
    {
        _health -= _damageReceived;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Movement()
    {
        _trBaseEnnemis.up = EnnemiManager.instance._trPlayer.position - _trBaseEnnemis.position;
        if (Vector2.Distance(_trBaseEnnemis.position, EnnemiManager.instance._trPlayer.position) > 7.5f)
        {
            _trBaseEnnemis.transform.position = Vector2.MoveTowards(_trBaseEnnemis.position, EnnemiManager.instance._trPlayer.position, _speed * Time.deltaTime);
        }
        else
        {

        }
    }
}
