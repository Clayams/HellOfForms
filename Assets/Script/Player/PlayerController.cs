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

    void Start()
    {
        _speed = 5f;
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
}
