using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5f;

    const float MIN_X = -10f;
    const float MAX_X = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.position += direction * speed * Time.deltaTime * Vector3.right;
        // Clamp the player's position to prevent it from going out of bounds
        float clampedX = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        transform.position = new Vector3(clampedX, transform.position.y, 0f);
    }
}
