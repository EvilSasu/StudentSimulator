using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform player;
    public PlayerController playerController;
    public float spawnInterval = 5f;
    public float spawnDistance = 10f;
    public float groundYPosition = -3.8f;

    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = 0f;
    }

    void Update()
    {
        if (playerController.IsGameOver()) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnGround();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnGround()
    {
        Vector3 spawnPosition = new Vector3(player.position.x + spawnDistance, groundYPosition, 0);
        Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
    }
}
