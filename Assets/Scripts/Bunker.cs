using UnityEngine;

public class Bunker : MonoBehaviour
{

    [SerializeField] int health = 3; // Health of the bunker

    SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is a player laser
        if (collision.CompareTag("PlayerLaser") || collision.CompareTag("EnemyLaser"))
        {
            Destroy(collision.gameObject); // Destroy the laser that hit the bunker
            health--; // Decrease the health of the bunker
            switch (health)
            {
                case 2:
                    spriteRenderer.color = Color.yellow; // Change the color of the bunker to yellow when health is 2
                    break;
                case 1:
                    spriteRenderer.color = Color.red; // Change the color of the bunker to red when health is 1
                    break;
                case 0:
                    Destroy(gameObject); // Destroy the bunker if health is zero
                    break;
            }
        }
    }
}
