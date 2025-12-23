using UnityEngine;

public class Spawning2 : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnZPosition = 116.0f;
    public float turnAngleY = 180.0f;

    // Update is called once per frame
    void Update()
    {
        int spawnChance = Random.Range(0, 700);
        if (spawnChance > 0) return;

        float spawnPositionX = Random.Range(-18, 19);

        Vector3 spawnOffsetLocal = new Vector3(spawnPositionX, 0, spawnZPosition);
        Vector3 spawnPosGlobal = transform.TransformPoint(spawnOffsetLocal);

        int animalIndex = Random.Range(0, animals.Length);
        Instantiate(animals[animalIndex], spawnPosGlobal, Quaternion.Euler(0, turnAngleY, 0));
    }
}
