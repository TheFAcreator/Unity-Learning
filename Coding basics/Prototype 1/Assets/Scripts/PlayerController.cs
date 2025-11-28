using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 35;
    private float horizontalInput;
    private float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player's input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }
}
