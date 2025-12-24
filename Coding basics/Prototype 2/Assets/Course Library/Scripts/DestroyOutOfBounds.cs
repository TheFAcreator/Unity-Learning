using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float zLimitHigh = 30.0f;

    void Update()
    {
        if (transform.position.z >= zLimitHigh && gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}