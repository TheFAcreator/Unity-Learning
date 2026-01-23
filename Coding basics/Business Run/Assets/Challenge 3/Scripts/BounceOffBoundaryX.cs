using UnityEngine;

public class BounceOffBoundaryX : MonoBehaviour
{
    public float direction = 1.0f;
    public float bounceStrength = 10.0f;
    public AudioClip bounceSound;

    private PlayerControllerX playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerController.gameOver) return;
        Rigidbody rb = other.GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * bounceStrength * direction, ForceMode.Impulse);
        GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(bounceSound, 1.0f);
    }
}
