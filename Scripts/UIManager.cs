using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text starScoreText;
    public Text healthText;
    public Player player; // 👈 reference to the Player script directly

    void Start()
    {
        // If you didn’t drag it in the Inspector, try to auto-find:
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    void Update()
    {
        if (player != null && healthText != null)
        {
            healthText.text = Player.getHealth().ToString() + " / 100";
        }

        if (starScoreText != null)
        {
            starScoreText.text = Star.GetStarsCollected() + " / " + Star.GetStarTotal();
        }
    }
}