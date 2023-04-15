using System;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private bool _shouldKeepMoving = false;
    private float _velocityX = 0f;
    private Rigidbody2D _rb2D;
    private float _forceCooldownTime = 1.0f;
    private float _lastTimeForceCalled = -Mathf.Infinity;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_shouldKeepMoving)
        {
            _rb2D.velocity = new Vector2(_velocityX, _rb2D.velocity.y);
        }
    }

    public void SetVelocity(float x)
    {
        _shouldKeepMoving = x != 0;
        _rb2D.velocity = new Vector2(x, _rb2D.velocity.y);
        _velocityX = x;

    }

    public void SetGravity(bool useGravity)
    {
        _rb2D.gravityScale = useGravity ? 1 : -0.5f;
    }

    public void AddForce(Vector2 force)
    {
        if (Time.time - _lastTimeForceCalled > _forceCooldownTime)
        {
            _rb2D.AddForce(force, ForceMode2D.Impulse);
            _lastTimeForceCalled = Time.time;
        }
    }
}