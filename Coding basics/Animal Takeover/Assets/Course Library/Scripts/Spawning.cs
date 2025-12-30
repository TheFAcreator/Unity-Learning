using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] animals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // InvokeRepeating("SpawnAnimal", 2.0f, 1.0f); is another way to spawn, but at intervals
    }

    // Update is called once per frame
    void Update()
    {
        int animalIndex = Random.Range(0, animals.Length);
        int spawnChance = Random.Range(0, 1000);
        int spawnPositionX = Random.Range(-20, 20);

        if (spawnChance < 1)
        {
            Instantiate(animals[animalIndex], new Vector3(spawnPositionX, 0, 30), animals[animalIndex].transform.rotation);
        }
    }
}
