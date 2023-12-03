using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private GameObject _gameIn;
    [SerializeField] private GameObject _gameOver;

    [SerializeField] private TextMeshProUGUI _hpInfo;
    [SerializeField] private TextMeshProUGUI _timerInfo;

    private EnnemiSpawner _enemySpawner;

    private float _speed;
    private int _health, _maxHealth = 3;

    void Start()
    {
        _enemySpawner = GetComponent<EnnemiSpawner>();
        _gameIn.SetActive(true);
        _gameOver.SetActive(false);
        _speed = 7.5f;
        _health = _maxHealth;
    }
    private void Update()
    {
        _hpInfo.text = "PV : " + _health.ToString();
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
        if (_health == 0 )
        {
            _gameIn.SetActive(false);
            _gameOver.SetActive(true);
        }
    }
}
