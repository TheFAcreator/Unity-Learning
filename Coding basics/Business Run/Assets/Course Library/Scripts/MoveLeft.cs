using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
