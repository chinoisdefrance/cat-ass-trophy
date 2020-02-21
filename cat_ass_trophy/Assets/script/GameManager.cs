using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    private bool gameEnded = false;

    public GameObject gameOverUI;

    public GameObject winUI;

    //at the end of the game, if Player Stats are lower or equal to zero, Game Over screen is loaded
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);
    }
}


