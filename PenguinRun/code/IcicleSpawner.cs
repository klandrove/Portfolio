using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleSpawner : MonoBehaviour
{
    public GameObject iciclePrefab;
    public float spawnInterval = 2f;
    public float minY = 5f;
    public float maxY = 10f;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    private float camHeight;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        InvokeRepeating("SpawnIcicle", spawnInterval, spawnInterval);
    }
    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        transform.position = new Vector3(cameraPosition.x, transform.position.y, transform.position.z);
    }

    public void SpawnIcicle()
    {
        Vector3 spawnPosition = gameObject.transform.position;
        spawnPosition.x = spawnPosition.x + Random.Range(-10, 10);
        Instantiate(iciclePrefab, spawnPosition, Quaternion.identity);
    }      

    
}
