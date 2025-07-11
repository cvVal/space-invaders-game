using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource; // Reference to the AudioSource component
    [SerializeField] AudioClip deathClip; // Reference to the death sound clip

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}
