using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 2f;       // horizontal speed
    public float moveTime = 2f;        // seconds before changing direction
    public int health = 100;

    [Header("Knockback Settings")]
    public float knockbackForce = 4f;
    public float knockbackDuration = 0.2f;

    [Header("Animation Statements")]
    //public bool isHit = false; 
    public bool isDead = false;
    public bool isKnockedBack = false;

    private float timer = 0f;
    private int moveDirection = -1;
    private SpriteRenderer spriteRenderer;

    private Vector3 lastPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnockedBack) return;

        // Move horizontally
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        bool isMoving = (Vector3.Distance(transform.position, lastPosition) > 0.001f);

        if (isMoving)
        {
            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                moveDirection *= -1; // reverse direction
                timer = 0f;
            }
        }
        // Flip sprite based on movement
        if (moveDirection != 0)
            spriteRenderer.flipX = moveDirection < 0;

        if (transform.position.y < -10.0f || health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            return;
        }

        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage();
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            StartCoroutine(Knockback(direction));
        }

    }

    private IEnumerator Knockback(Vector3 direction)
    {
        isKnockedBack = true;

        float timer = 0f;
        while (timer < knockbackDuration)
        {
            transform.position += direction * knockbackForce * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }

        isKnockedBack = false;
    }

    public void TakeDamage()
    {
        health -= 25;
        Debug.Log("Health: "+health);
    }
}
