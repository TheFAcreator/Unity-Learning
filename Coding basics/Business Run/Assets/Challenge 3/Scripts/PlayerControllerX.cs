using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{

    public float floatForce;
    public float gravityModifier = 1.5f;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    internal bool gameOver = false;

    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private MeshRenderer playerMesh;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerMesh = GetComponent<MeshRenderer>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up, ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            //playerRb.AddForce(Vector3.up * floatForce, ForceMode.VelocityChange);
            Vector3 vel = playerRb.linearVelocity;
            vel.y = Mathf.Lerp(vel.y, floatForce, 0.2f);
            playerRb.linearVelocity = vel;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");

            Destroy(other.gameObject);
            playerMesh.enabled = false;
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);

            Destroy(other.gameObject);
        }
    }
}
