using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3; // Number of lives the player starts with

    public void WinGame()
    {
        Debug.Log("You Win!");
        // Here you can add code to handle what happens when the player wins, like showing a win screen or restarting the game.
    }

    public void LoseLife()
    {
        playerLives--;
        Debug.Log("Player lost a life. Lives remaining: " + playerLives);
        if (playerLives <= 0)
        {
            Debug.Log("Game Over!");
            GameOver();
        }
        else
        {
            Debug.Log("Player respawned. Lives remaining: " + playerLives);
            RespawnPlayer();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! You have no lives left.");
    }

    void RespawnPlayer()
    {
        Debug.Log("Player respawned.");
    }
}
