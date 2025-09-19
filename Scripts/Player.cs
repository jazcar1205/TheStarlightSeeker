
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class Player : PhysicsBase
{
    [Header("Player Stats")]
    public float moveSpeed = 3f;
    public float jumpForce = 6f;
    public static int health = 100;

    [Header("Attack Settings")]
    public GameObject wand;
    public float attackDuration = 0.3f;

    private bool isAttacking = false;
    private CircleCollider2D wandCollider;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        wandCollider = wand.GetComponent<CircleCollider2D>();
        wandCollider.radius = 0.5f; 
        wand.SetActive(false);

        
    }

    void Update()
    {
        gameObject.tag = "Player";
        MovementHandling();

        if (animator != null)
        {
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("yVelocity", velocity.y);
        }

        if (!isAttacking) {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Starting attack!");
                StartCoroutine(PerformAttack());
            }
        }
    }

    void MovementHandling()
    {
        desiredx = 0f;

        if (Input.GetAxis("Horizontal") > 0) desiredx = moveSpeed;
        if (Input.GetAxis("Horizontal") < 0) desiredx = -moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = jumpForce;

        isRunning = Mathf.Abs(desiredx) > 0.01f;

        if (desiredx != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(desiredx) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

    }


    public static int getHealth() 
    { 
        return health; 
    }

    public static void ResetHealth() 
    { 
        health = 100; 
    }

    public void TakeDamage()
    {
        health -= 15;
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        wandCollider.radius = 0.8f;
        wand.SetActive(true);

        Debug.Log("Happening!");

        if (animator != null)
        {
            animator.SetTrigger("Attack"); 
        }

        yield return new WaitForSeconds(attackDuration);

        
        wand.SetActive(false);
        wandCollider.radius = 0.5f;
        isAttacking = false;
    }

}

