using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] GameManager gameManager; // Reference to the GameManager script

    Vector3 direction = Vector3.right; // Default direction to the right
    float changeDirectionCooldown = 0f; // Time in seconds before changing direction

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeDirectionCooldown += Time.deltaTime;
        if (gameManager.isPlayerAlive)
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }

    public void ChangeDirection()
    {
        if (changeDirectionCooldown > 0.5f) // Change direction every 0.5 seconds
        {
            direction *= -1f; // Reverse the direction
            changeDirectionCooldown = 0f; // Reset the cooldown
            transform.position += Vector3.down; // Move all enemies down slightly when changing direction
        }
    }
}
