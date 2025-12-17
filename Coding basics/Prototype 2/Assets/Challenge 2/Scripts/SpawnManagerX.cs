using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBallCoroutine());
    }

    // Coroutine to spawn random ball at random x position at top of play area
    IEnumerator SpawnRandomBallCoroutine()
    {
        // Wait for initial delay
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            // Spawn random ball
            SpawnRandomBall();

            // Get new interval time
            spawnInterval = Random.Range(1.0f, 4.0f);

            // Wait for next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], spawnPos, ballPrefabs[0].transform.rotation);
    }
}
