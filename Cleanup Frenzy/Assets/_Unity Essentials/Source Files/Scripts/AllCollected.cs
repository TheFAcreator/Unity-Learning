using UnityEngine;
using System;

public class CollectibleCompletionVFX : MonoBehaviour
{
    public GameObject allCollectedVFX;
    public GameObject allCollectedVFX2;
    private bool vfxTriggered = false;
    private Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }

    void Update()
    {
        if (vfxTriggered) return;

        // Count remaining collectibles
        Type collectibleType = Type.GetType("Collectible");
        int remaining = 0;

        if (collectibleType != null)
        {
            remaining += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            remaining += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Trigger VFX if none remain
        if (remaining == 0)
        {
            Instantiate(allCollectedVFX, playerTransform.position, Quaternion.identity);
            Instantiate(allCollectedVFX2, playerTransform.position, Quaternion.identity);
            vfxTriggered = true; // prevent multiple spawns
        }
    }
}
