using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] GameObject laserPrefab;

    const float MIN_X = -10f;
    const float MAX_X = 10f;

    float laserCooldown = 0f; // Cooldown time in seconds

    GameManager gameManager; // Reference to the GameManager script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); // Find the GameManager in the scene
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player left or right based on input
        // Get the horizontal input axis (left/right arrow keys or A/D keys)
        float direction = Input.GetAxis("Horizontal");
        transform.position += direction * speed * Time.deltaTime * Vector3.right;

        // Clamp the player's position to prevent it from going out of bounds
        float clampedX = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        transform.position = new Vector3(clampedX, transform.position.y, 0f);

        // Check if the player pressed the fire button
        laserCooldown += Time.deltaTime; // Increment cooldown timer
        if (Input.GetButtonDown("Fire1") && laserCooldown > 0.3f)
        {
            Shoot();
            laserCooldown = 0f; // Reset cooldown timer after shooting
        }
    }

    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is an enemy laser
        if (collision.CompareTag("EnemyLaser"))
        {
            gameManager.LoseLife(); // Call the LoseLife method from GameManager
            Destroy(collision.gameObject); // Destroy the enemy laser that hit the player
            Destroy(gameObject); // Destroy the player itself
            Debug.Log("Player destroyed by enemy laser!");
        }
    }
}
