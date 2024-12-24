using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public int scoreValue = 100;  // Score value for hitting a pig
    public ParticleSystem destructionEffect;  // Particle effect to play when pig is hit
    public AudioClip hitSound;  // Sound effect for hitting a pig
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the audio source attached to the bird
    }

    // Called when the bird collides with another object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pig"))
        {
            // Play destruction effect (e.g., explosion or particles)
            if (destructionEffect != null)
            {
                Instantiate(destructionEffect, collision.transform.position, Quaternion.identity);
            }

            // Play hit sound
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            // Destroy the pig (or other objects with the "Pig" tag)
            Destroy(collision.gameObject);

            // Add score for hitting a pig
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }
}
