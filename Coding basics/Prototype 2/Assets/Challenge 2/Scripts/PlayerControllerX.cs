using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireCooldown = 1.0f; // seconds

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextFireTime = Time.time + fireCooldown;
        }
    }
}