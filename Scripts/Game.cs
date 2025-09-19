using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject Portal;
    public GameObject PlayerOb;

    private Vector2 protalPos;
    private static Vector2 playerPos;
    public bool winning= false;


    void Update()
    {

        protalPos = Portal.transform.position;
        playerPos = PlayerOb.transform.position;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Star.ResetStars();
            Player.ResetHealth();
            SceneManager.LoadScene("MainMenu");
        }


        ChangeLevel();
        DeadCheck();
    }

    void ChangeLevel()
    {
        if (Vector2.Distance(protalPos, playerPos) < 2.0f)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex == 4)
            {
                EndGameCheck();
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            
        }
    }

    public void DeadCheck()
    {
        if (Player.getHealth() <= 0|| playerPos.y < -10)
        {
            Debug.Log("Is Winning: " + winning);
            EndGameCheck();
        }
    }

    void EndGameCheck()
    {
        if (Star.GetStarsCollected() == Star.GetStarTotal())
        {
            winning = true;
            Debug.Log("Check stars All collected - Winning: " + winning);
            Debug.Log("Stars Collected " + Star.GetStarsCollected());
            Debug.Log("Total Stars " + Star.GetStarTotal());
        }
        else
        {
            winning= false;
            Debug.Log("Not Winning: " + winning);
        }
        Star.ResetStars();
        Player.ResetHealth();
        GameState.status = winning;
        SceneManager.LoadScene("EndMenu");



    }

}
