using UnityEngine;

public class OnTouch : MonoBehaviour
{
    private AudioClip touchSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        touchSound = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(touchSound, transform.position);
            Destroy(other.gameObject);
        }
    }
}
