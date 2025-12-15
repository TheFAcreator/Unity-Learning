using UnityEngine;

public class DestroyAfterLimit : MonoBehaviour
{
    private float zLimitHigh = 30.0f;
    private float zLimitLow = -18.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= zLimitHigh)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z <= zLimitLow)
        {
            Destroy(gameObject);

            Debug.Log("Game Over!");
        }
    }
}
