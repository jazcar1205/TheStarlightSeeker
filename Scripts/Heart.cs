using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float pickupRadius = 0.75f; 
    private Transform playerTransform;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Check distance to player
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= pickupRadius)
        {
            PowerUp();
        }
    }

    public void PowerUp()
    {
        Debug.Log("Power up! :" + Player.health);
        Player.health += 15;
        if (Player.health > 100) Player.health = 100;
        
        Destroy(gameObject);
    }

    
}
