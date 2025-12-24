using System.Collections;
using UnityEngine;

public class Spawning2 : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnZPosition = 116.0f;
    public float turnAngleY = 180.0f;
    public int spawnChance = 1000;

    void Start()
    {
        if (animals.Length == 4)
            StartCoroutine(SpawnChick());
    }

    void Update()
    {
        int spawnNumber = Random.Range(0, spawnChance);
        if (spawnNumber > 0) return;

        int animalIndex = Random.Range(0, animals.Length);
        GetRandomPositionAndInstantiate(animalIndex);
    }

    Vector3 GetRandomPositionAndInstantiate(int index)
    {
        float spawnPositionX = Random.Range(-18, 19);

        Vector3 spawnOffsetLocal = new Vector3(spawnPositionX, 0, spawnZPosition);
        Vector3 spawnPosGlobal = transform.TransformPoint(spawnOffsetLocal);

        Instantiate(animals[index], spawnPosGlobal, Quaternion.Euler(0, turnAngleY, 0));

        return spawnPosGlobal;
    }

    IEnumerator SpawnChick()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            Debug.Log("Spawning chick!");
            GetRandomPositionAndInstantiate(3);
        }
    }
}