using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemiesManager enemiesManager; // Reference to the EnemiesManager script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is a player laser
        if (collision.CompareTag("PlayerLaser"))
        {
            Destroy(collision.gameObject); // Destroy the laser that hit the enemy
            Destroy(gameObject); // Destroy the enemy itself
        }

        if (collision.CompareTag("Wall"))
        {
            enemiesManager.ChangeDirection(); // Change the direction of the enemies when they hit a wall
        }
    }
}
