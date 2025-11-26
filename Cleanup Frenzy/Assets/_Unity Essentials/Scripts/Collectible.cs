using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    private AudioSource aus;
    public AudioClip collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            // Play the collection sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the collection effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
