using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3; // Number of lives the player starts with
    [SerializeField] float respawnDelay = 1f; // Delay before respawning the player
    [SerializeField] GameObject playerPrefab; // Reference to the player prefab
    [SerializeField] Transform playerSpawnPoint; // Point where the player will respawn

    public bool isPlayerAlive = true; // Track if the player is alive
    int playerScore = 0; // Player's score

    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Score added: " + points + ". Total score: " + playerScore);
    }

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
            Invoke(nameof(RespawnPlayer), respawnDelay); // Respawn the player after a delay
        }
    }

    void GameOver()
    {
        isPlayerAlive = false; // Player has no lives left
        Debug.Log("Game Over! You have no lives left.");
    }

    void RespawnPlayer()
    {
        isPlayerAlive = true; // Player is now alive again
        Debug.Log("Player respawned.");
        // Instantiate a new player at the spawn point
        Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
    }
}
