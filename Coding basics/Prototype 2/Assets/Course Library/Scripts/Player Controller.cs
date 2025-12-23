using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    public float zLimitHigh = 30.0f;
    public float zLimitLow = -18.0f;

    public float speed = 10f;
    public float xRange = 20f;
    public float zRangePos = -48f;
    public float zRangeNeg = -7f;
    public GameObject projectilePrefab;
    public float projectileScale = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectilePrefab.transform.localScale = new Vector3(projectileScale, projectileScale, projectileScale);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player left and right, while keeping them within bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        // Move the player forward and back, while keeping them within bounds
        if (transform.position.z < zRangeNeg)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeNeg);
        }
        else if (transform.position.z > zRangePos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangePos);
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);


        // Launch a projectile when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
