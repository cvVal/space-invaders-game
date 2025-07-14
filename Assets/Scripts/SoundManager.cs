using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource; // Reference to the AudioSource component
    
    [Header("Sound Effects")]
    [SerializeField] AudioClip enemyDeathClip; // Sound when enemy is destroyed
    [SerializeField] AudioClip playerHitClip; // Sound when player is hit/destroyed
    [SerializeField] AudioClip playerLaserClip; // Sound when player fires laser
    [SerializeField] AudioClip enemyLaserClip; // Sound when enemy fires laser

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    public void PlayEnemyDeathSound()
    {
        if (enemyDeathClip != null)
            audioSource.PlayOneShot(enemyDeathClip);
    }
    
    public void PlayPlayerHitSound()
    {
        if (playerHitClip != null)
            audioSource.PlayOneShot(playerHitClip);
    }
    
    public void PlayPlayerLaserSound()
    {
        if (playerLaserClip != null)
            audioSource.PlayOneShot(playerLaserClip);
    }
    
    public void PlayEnemyLaserSound()
    {
        if (enemyLaserClip != null)
            audioSource.PlayOneShot(enemyLaserClip);
    }
}
