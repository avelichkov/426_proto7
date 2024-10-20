using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _maxFallSpeed;
    [SerializeField] GameObject _deathEffect;
    private Rigidbody2D _rb;
    private CircleCollider2D _cc;
    private bool winSoundPlayed = false;

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
        AudioManager.instance.Play("Jump");
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Spike"))
        {
            AudioManager.instance.Play("Death");
            GameObject instance = Instantiate(_deathEffect);
            instance.transform.localScale = transform.localScale;
            instance.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if (other.transform.CompareTag("FinishLine"))
        {
            if (!winSoundPlayed)
            {
                AudioManager.instance.Play("Victory");
                winSoundPlayed = true;
            }
            GameManager.instance.isGameOver = true;
            Jump();
        }
    }
}
