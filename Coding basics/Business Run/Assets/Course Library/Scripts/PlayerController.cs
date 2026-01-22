using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityMultiplier = 1f;
    public ParticleSystem deathVFX;
    public ParticleSystem dirtVFX;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip landSound;

    internal bool gameOver = false;

    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    private bool isGrounded = true;
    private Animator playerAnim;
    private BoxCollider playerCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * 3000f, ForceMode.Impulse);
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            dirtVFX.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            audioSource.PlayOneShot(landSound, 0.5f);
            isGrounded = true;
            dirtVFX.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            audioSource.PlayOneShot(crashSound, 1.0f);

            dirtVFX.Stop();
            deathVFX.Play();

            playerCollider.center = new Vector3(
                playerCollider.center.x,
                playerCollider.center.y,
                playerCollider.center.z - 1.5f
            );


            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
