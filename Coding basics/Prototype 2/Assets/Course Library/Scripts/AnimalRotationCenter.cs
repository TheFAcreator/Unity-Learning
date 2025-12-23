using UnityEngine;
using System.Collections.Generic;

public class AnimalRotationCenter : MonoBehaviour
{
    public float targetAngle; // Positive = right, Negative = left

    private Dictionary<Transform, AnimalRotationData> rotatingAnimals = new();

    private class AnimalRotationData
    {
        public float remainingAngle;
        public float radius;
        public float speed;
    }

    void Update()
    {
        List<Transform> completedAnimals = new();

        foreach (var kvp in rotatingAnimals)
        {
            Transform animal = kvp.Key;
            AnimalRotationData data = kvp.Value;

            if (Mathf.Abs(data.remainingAngle) <= 0.01f)
            {
                completedAnimals.Add(animal);
                continue;
            }

            // Calculate angular velocity (radians per second)
            float angularSpeed = data.speed / data.radius;
            float angleThisFrame = angularSpeed * Time.deltaTime * Mathf.Rad2Deg; // convert to degrees

            // Clamp to remaining angle
            if (Mathf.Abs(angleThisFrame) > Mathf.Abs(data.remainingAngle))
            {
                angleThisFrame = data.remainingAngle;
            }

            // Only rotate the animal's Y-axis (steering)
            animal.Rotate(0, angleThisFrame, 0, Space.World /* can be ommitted if the animal's X and Z axis are not being modified throughout its lifetime (no tilting)*/);
                // OR Rotate around the center point - animal.RotateAround(transform.position, Vector3.up, angleThisFrame);

            data.remainingAngle -= angleThisFrame;
        }

        foreach (Transform animal in completedAnimals)
        {
            rotatingAnimals.Remove(animal);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Transform animal = other.transform;

            if (rotatingAnimals.ContainsKey(animal))
                return;

            MoveForward movement = animal.GetComponent<MoveForward>();

            float radius = (animal.position - transform.position).magnitude;

            AnimalRotationData data = new AnimalRotationData
            {
                remainingAngle = targetAngle,
                radius = radius,
                speed = movement.speed
            };

            rotatingAnimals.Add(animal, data);
        }
    }
}