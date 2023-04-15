using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2D;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalking, _rb2D.velocity.x != 0);
        _spriteRenderer.flipX = _rb2D.velocity.x < 0;
        _spriteRenderer.flipY = _rb2D.gravityScale < 0;
    }
}