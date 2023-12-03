using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnnemiShoot : MonoBehaviour
{
    private Transform _trEnnemi;

    public float _bulletLife = 5f;
    public float _bulletRotation = 0f;
    public float _bulletSpeed = 5f;

    private Vector2 _spawnPoint;
    private float _timer = 0f;
    void Start()
    {
        _trEnnemi = GetComponent<Transform>();
        _spawnPoint = new Vector2(_trEnnemi.position.x, _trEnnemi.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _bulletLife)
        {
            Destroy(this.gameObject);
        }
        _timer += Time.deltaTime;
        _trEnnemi.position = EnnemiBulletMovement(_timer);
    }

    private Vector2 EnnemiBulletMovement(float _timer)
    {
        float x = _timer * _bulletSpeed * _trEnnemi.up.x;
        float y = _timer * _bulletSpeed * _trEnnemi.up.y;
        return new Vector2(x + _spawnPoint.x, y + _spawnPoint.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.PlayerTakeDamage(1);
        }
    }
}
