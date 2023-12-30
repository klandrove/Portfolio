using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cloudSpeed = Random.Range(0.001f, 0.01f);
        Vector3 speed = transform.position;
        speed.x += cloudSpeed;
        transform.position = speed;

        if (speed.x >= 50){
            Destroy(gameObject);
            return;
        }
    }
}
