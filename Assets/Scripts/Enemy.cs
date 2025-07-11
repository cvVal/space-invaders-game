using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemiesManager enemiesManager; // Reference to the EnemiesManager script
    [SerializeField] GameManager gameManager; // Reference to the GameManager script
    [SerializeField] GameObject enemyLaserPrefab; // Prefab for the enemy laser
    [SerializeField] int points = 100; // Points awarded for destroying this enemy
    
    
    [Header("Fire Rate Settings")]
    [SerializeField] float baseFireRate = 1.5f; // Base time between shots
    [SerializeField] float fireRateVariation = 0.5f; // Random variation in fire rate
    [SerializeField] float aggressionMultiplier = 1.2f; // How much more aggressive enemies get as numbers decrease
    
    private float nextFireTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextFireTime();
    }
    
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireLaser();
            SetNextFireTime();
        }
    }
    
    void SetNextFireTime()
    {
        // Calculate dynamic fire rate based on remaining enemies
        float enemyCount = transform.parent.childCount;
        float dynamicFireRate = baseFireRate;
        
        // As enemies decrease, increase fire rate (but cap it to prevent being too aggressive)
        if (enemyCount < 10)
        {
            dynamicFireRate = baseFireRate / Mathf.Min(aggressionMultiplier, 1.8f);
        }
        
        // Add random variation to make it feel more organic
        float variation = Random.Range(-fireRateVariation, fireRateVariation);
        dynamicFireRate = Mathf.Max(0.8f, dynamicFireRate + variation); // Minimum 0.8 seconds between shots
        
        nextFireTime = Time.time + dynamicFireRate;
    }

    void FireLaser()
    {
        if (Random.value < (2f / transform.parent.childCount)) // Fire a laser based on the number of enemies left
        {
            if (gameManager.isPlayerAlive) // Check if the player is still alive
            {
                Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is a player laser
        if (collision.CompareTag("PlayerLaser"))
        {
            gameManager.AddScore(points); // Add points to the score in GameManager

            if (transform.parent.childCount <= 1)
            {
                gameManager.WinGame(); // Call the WinGame method from GameManager if this is the last enemy
            }
            Destroy(collision.gameObject); // Destroy the laser that hit the enemy
            Destroy(gameObject); // Destroy the enemy itself
        }

        if (collision.CompareTag("Wall"))
        {
            enemiesManager.ChangeDirection(); // Change the direction of the enemies when they hit a wall
        }
    }
}
