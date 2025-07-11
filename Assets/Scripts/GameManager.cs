using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3; // Number of lives the player starts with
    [SerializeField] float respawnDelay = 1f; // Delay before respawning the player
    [SerializeField] GameObject playerPrefab; // Reference to the player prefab
    [SerializeField] Transform playerSpawnPoint; // Point where the player will respawn

    [SerializeField] TextMeshProUGUI scoreText; // UI text to display the score
    [SerializeField] TextMeshProUGUI livesText; // UI text to display the player's lives

    [SerializeField] GameObject winPanel; // UI panel to show when the player wins
    [SerializeField] GameObject gameOverPanel; // UI panel to show when the game is over

    [SerializeField] SoundManager soundManager; // Reference to the SoundManager script

    public bool isPlayerAlive = true; // Track if the player is alive
    int playerScore = 0; // Player's score

    void Start()
    {
        UpdateUI(); // Initialize the UI with starting values
    }

    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Score added: " + points + ". Total score: " + playerScore);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = playerScore.ToString(); // Update the score text
        livesText.text = playerLives.ToString(); // Update the lives text
    }

    public void WinGame()
    {
        isPlayerAlive = false; // Player has won the game
        Debug.Log("You Win!");
        winPanel.SetActive(true); // Show the win panel
    }

    public void LoseLife()
    {
        // Play player death sound only if soundManager is assigned
        if (soundManager != null)
        {
            soundManager.PlayDeathSound();
        }
        else
        {
            Debug.LogWarning("SoundManager is not assigned to PlayerController!");
        }
        playerLives--;
        Debug.Log("Player lost a life. Lives remaining: " + playerLives);
        UpdateUI(); // Update the UI to reflect the new number of lives

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
        DestroyAllPlayerLasers(); // Destroy all remaining player lasers
        Debug.Log("Game Over! You have no lives left.");
        gameOverPanel.SetActive(true); // Show the game over panel
    }

    void DestroyAllPlayerLasers()
    {
        // Find and destroy all objects with the "PlayerLaser" tag
        GameObject[] playerLasers = GameObject.FindGameObjectsWithTag("PlayerLaser");
        foreach (GameObject laser in playerLasers)
        {
            Destroy(laser);
        }
        Debug.Log("Destroyed " + playerLasers.Length + " player lasers.");
    }

    void RespawnPlayer()
    {
        isPlayerAlive = true; // Player is now alive again
        Debug.Log("Player respawned.");
        // Instantiate a new player at the spawn point
        Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
