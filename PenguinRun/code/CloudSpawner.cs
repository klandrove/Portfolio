using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 6f;
    public Transform spawnPoint;
    public float minY = 3f;
    public float maxY = 8f;
    public float minScale = 0.1f;
    public float maxScale = 0.8f;


    void Start()
    {
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }

    void Spawn()
    {
        float xPos = spawnPoint.position.x;
        float yPos = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(xPos, yPos, 0);
        float scale = Random.Range(minScale, maxScale);
        Vector3 cloudScale = new Vector3(scale, scale, 1f);
        GameObject cloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        cloud.transform.localScale = cloudScale;
        
    }

}