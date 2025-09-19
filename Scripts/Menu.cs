using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text mainMessage;
    [SerializeField] private Text subMessage;
    [SerializeField] private Image panelImage;

    private string win = "You’ve banished the eternal darkness and restored the Starverse!";
    private string lose = "You could not stop the eternal darkness — the Starverse fades away.";

    void Start()
    {
        if (GameState.status == true) // win
        {
            Debug.Log("WON!");
            mainMessage.text = win;
            subMessage.text = win;
            panelImage.color = new Color32(246, 246, 246, 255);
        }
        else // lose
        {
            Debug.Log("LOST!");
            mainMessage.text = lose;
            subMessage.text = lose;
            panelImage.color = new Color32(32, 32, 32, 251);
        }
    }

    public void ToGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void ToStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToInstructions()
    {

        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
