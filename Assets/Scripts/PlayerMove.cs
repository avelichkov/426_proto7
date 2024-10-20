using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _maxFallSpeed;
    [SerializeField] GameObject _deathEffect;
    Rigidbody2D _rb;
    CircleCollider2D _cc;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CircleCollider2D>();

        _rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.R) && !Input.GetKeyDown(KeyCode.Escape))
        { 
            _rb.gravityScale = _gravity;
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Cap the velocity
        if (_rb.velocity.magnitude > _maxFallSpeed && _rb.velocity.y < 0)
        {
            _rb.velocity = _rb.velocity.normalized * _maxFallSpeed;
        }
    }

    private void Jump()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (HasTag(other,"Spike"))
        {
            Instantiate(_deathEffect);
            Destroy(this.gameObject);
        }
    }

    private bool HasTag(Collider2D col, string tagName)
    {
        return col.transform.CompareTag(tagName);
    }
}
