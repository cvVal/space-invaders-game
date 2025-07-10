using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is a player or a laser
        if (collision.CompareTag("PlayerLaser"))
        {
            // Destroy the object that entered the trigger
            Destroy(collision.gameObject);
        }
    }
}
