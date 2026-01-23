using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        StartCoroutine(SpawnAtRandomIntervals());
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(2, 13), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }

    IEnumerator SpawnAtRandomIntervals()
    {
        while (!playerControllerScript.gameOver)
        {
            float randomInterval = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(randomInterval);
            SpawnObjects();
        }
    }
}
