using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [Header("Hunger Settings")]
    public float hunger;

    [Header("UI References")]
    public GameObject hungerBarPrefab;
    public Transform uiAnchor;

    private float minHunger = 0f;
    private GameObject hungerBarInstance;
    private Slider hungerSlider;

    void Start()
    {
        hungerBarInstance = Instantiate(hungerBarPrefab);

        hungerSlider = hungerBarInstance.GetComponentInChildren<Slider>();
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
    }

    void LateUpdate()
    {
        if (hungerBarInstance == null) return;
        hungerBarInstance.transform.position = uiAnchor.position;

        Vector3 directionToCamera = Camera.main.transform.position - hungerBarInstance.transform.position;
        directionToCamera.x = 0;
        directionToCamera.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        hungerBarInstance.transform.rotation = targetRotation * Quaternion.Euler(0, 180, 0);
    }

    public void Feed(float foodAmount)
    {
        hunger -= foodAmount;

        // Clamp so it doesn't exceed minHunger
        hunger = Mathf.Clamp(hunger, 0, 250);

        StartCoroutine(SmoothHungerChange(hunger));

        if (hunger <= minHunger)
        {
            GameUIManager instance = FindFirstObjectByType<GameUIManager>();

            Destroy(gameObject);
            if (hungerBarInstance != null) Destroy(hungerBarInstance);

            instance.AddScore(1);

            if (gameObject.CompareTag("Chick"))
            {
                instance.AddHeart();
                instance.AddScore(2);
            }
        }
    }

    IEnumerator SmoothHungerChange(float target)
    {
        float start = hungerSlider.value;
        float time = 0f;
        float duration = 0.5f;

        while (time < duration)
        {
            time += Time.deltaTime;
            hungerSlider.value = Mathf.Lerp(start, target, time / duration);
            yield return null;
        } 
        hungerSlider.value = target;
    }
}