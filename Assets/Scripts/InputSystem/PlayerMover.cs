using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _movementDirection;
    private Rigidbody2D _rigidbody2D;

    private float _speedBooster = 7f;
        
    public bool IsMoving { get; private set; }
    public Vector2 MovementDirection => _movementDirection;
    public PlayerInput Input => _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementDirection = _input.Player.Move.ReadValue<Vector2>() * _speedBooster;

        IsMoving = (_movementDirection.x > 0.1f || _movementDirection.x < -0.1f) || (_movementDirection.y > 0.1f || _movementDirection.y < -0.1f) ? true : false;
    }

    private void FixedUpdate()
    {
        Movement(_movementDirection);   
    }

    private void Movement(Vector2 direction)
    {
        _rigidbody2D.velocity = new Vector2(direction.x, direction.y);
    }
}
