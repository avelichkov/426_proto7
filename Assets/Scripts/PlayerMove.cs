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
    public SpriteRenderer sr;
    private Color colorCyan = Color.cyan;
    private Color colorYellow = Color.yellow;
    private Color colorMagenta = new Color(140f / 255f, 19f / 255f, 250f / 255f);
    private Color colorPink = new Color(1f, 0f, 0.502f);
    private CircleCollider2D _cc;
    public string currentColor;
    private bool winSoundPlayed = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CircleCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>(); // Use GetComponentInChildren if necessary
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
        if (other.transform.CompareTag("ColorChanger")) {
            SetRandomColor();
            Destroy(other.gameObject);
        }

        else if (other.transform.CompareTag("Spike"))
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
        else if (other.transform.CompareTag("Cyan") && currentColor != "Cyan"){
            AudioManager.instance.Play("Death");
            GameObject instance = Instantiate(_deathEffect);
            instance.transform.localScale = transform.localScale;
            instance.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if(other.transform.CompareTag("Magenta") && currentColor != "Magenta")
        {
            AudioManager.instance.Play("Death");
            GameObject instance = Instantiate(_deathEffect);
            instance.transform.localScale = transform.localScale;
            instance.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if(other.transform.CompareTag("Pink") && currentColor != "Pink")
        {
            AudioManager.instance.Play("Death");
            GameObject instance = Instantiate(_deathEffect);
            instance.transform.localScale = transform.localScale;
            instance.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if (other.transform.CompareTag("Yellow") && currentColor != "Yellow")
        {
            AudioManager.instance.Play("Death");
            GameObject instance = Instantiate(_deathEffect);
            instance.transform.localScale = transform.localScale;
            instance.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 3);
        if(currentColor == "Cyan" && index == 0)
        {
            index = Random.Range(1, 3);
        }
        else if (currentColor == "Yellow" && index == 1)
        {
            index = Random.Range(2, 3);
        }
        else if(currentColor == "Magenta" && index == 2)
        {
            index = Random.Range(0, 1);
        }
        else if(currentColor == "Pink" && index == 3)
        {
            index = Random.Range(0, 2);
        }

        switch (index) {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }


    }
}
