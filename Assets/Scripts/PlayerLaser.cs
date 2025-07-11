using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is an enemy laser
        if (collision.CompareTag("EnemyLaser"))
        {
            Destroy(collision.gameObject); // Destroy the enemy laser that was hit by the player's laser
            Destroy(gameObject); // Destroy the player's laser itself
        }
    }
}
