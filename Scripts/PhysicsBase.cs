using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBase : MonoBehaviour
{
    [Header("Movement Stats")]
    public Vector2 velocity;
    public float gravityFactor;
    public float desiredx;

    [Header("Animation Stats")]
    public bool isGrounded; 
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Movement(Vector2 move, bool horizontal)
    {
        if (move.magnitude < 0.00001f) return;
        isGrounded = false;

        RaycastHit2D[] hits = new RaycastHit2D[16];
        int cnt = GetComponent<Rigidbody2D>().Cast(move, hits, move.magnitude + 0.01f);
        
        for (int i = 0; i <cnt; ++i)
        {
            if (Mathf.Abs(hits[i].normal.x) > 0.3f && horizontal)
            {
                // Only block if hitting a real wall
                if (Mathf.Abs(move.x) > 0.01f)
                    move.x = 0; // stop movement
            }


            if (Mathf.Abs(hits[i].normal.y) > 0.3f && !horizontal)
            {
                if (hits[i].normal.y > 0.3f) isGrounded = true;
                return;
            }

        }

        transform.position += (Vector3)move;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply gravity
        Vector2 acceleration = 9.81f * Vector2.down * gravityFactor;
        velocity += acceleration * Time.fixedDeltaTime;
        velocity.x = desiredx;
        
        // Move with collision handling
        Vector2 move = velocity * Time.fixedDeltaTime;
        Movement(new Vector3(move.x, 0), true);
        Movement(new Vector3(0,move.y),false);
    }

}
