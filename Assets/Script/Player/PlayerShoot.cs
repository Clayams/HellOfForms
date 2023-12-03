using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Transform _trPlayer;

    public float _bulletLife = 5f;
    public float _bulletRotation = 0f;
    public float _bulletSpeed = 5f;
    public int _bulletDamage = 10;

    private Vector2 _spawnPoint;
    private float _timer = 0f;
    void Start()
    {
        _trPlayer = GetComponent<Transform>();
        _spawnPoint = new Vector2(_trPlayer.position.x, _trPlayer.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if( _timer > _bulletLife )
        {
            Destroy(this.gameObject);
        }
        _timer += Time.deltaTime;
        _trPlayer.position = BulletMovement(_timer);
    }

    private Vector2 BulletMovement(float _timer)
    {
        float x = _timer * _bulletSpeed * _trPlayer.up.x;
        float y = _timer * _bulletSpeed * _trPlayer.up.y;
        return new Vector2(x + _spawnPoint.x, y + _spawnPoint.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<BaseEnnemis>(out BaseEnnemis baseEnnemis))
        {
            baseEnnemis.TakeDamage(_bulletDamage);
        }
    }
}
