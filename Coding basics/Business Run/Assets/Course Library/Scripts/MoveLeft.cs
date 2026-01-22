using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -15.0f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
