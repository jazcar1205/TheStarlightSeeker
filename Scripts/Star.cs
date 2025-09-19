using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static int totalStars = 0;
    public static int collectedStars = 0;

    public float collectDistance = 1.00f; // how close player needs to be to collect

    private Transform playerTransform;

    void Awake()
    {
        totalStars++;
    }

    void Start()
    {
        // Find the player in the scene by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    void Update()
    {
        // Did position based pickup as instabilities were neverending with Ontrigger 
       if (playerTransform == null) return;

        // Check distance to player
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= collectDistance)
        {
            Collect();
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter Trigger On!");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Star collected!");
            Collect();
        }
    }*/

    void Collect()
    {
        collectedStars++;
        Debug.Log("Collected star! Total: " + collectedStars);
        Destroy(gameObject);
    }

    public static int GetStarsCollected() { return collectedStars; }

    public static int GetStarTotal() { return totalStars; }

    public static void ResetStars()
    {
        totalStars = 0;
        collectedStars = 0;
    }
}
