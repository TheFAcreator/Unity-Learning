using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("How many real-time seconds one full in-game day lasts.")]
    public float dayLengthInSeconds = 60;

    // rotation speed computed from day length
    private float rotationSpeed;

    void Start()
    {
        // 360 degrees per day
        rotationSpeed = 360f / dayLengthInSeconds;
    }

    void Update()
    {
        // Rotate light around its X axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
