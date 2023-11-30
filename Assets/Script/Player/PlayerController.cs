using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _speed;
    private int _health, _maxHealth = 3;

    void Start()
    {
        _speed = 7.5f;
        _health = _maxHealth;
    }
    private void Update()
    {
        Debug.Log(_health);
    }

    public void Move(Vector2 _movement)
    {
        _rigidbody.velocity = _movement * _speed;
    }
    public void Movement(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        Move(move);
    }

    public void PlayerTakeDamage(int _playerTakeDamage)
    {
        _health -= _playerTakeDamage;

        if (_health == 0)
        {
            Destroy(gameObject);
        }
    }
}
