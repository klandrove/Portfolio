using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowastro : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = playerTransform.position + playerTransform.TransformDirection(offset);
        transform.position = newPosition;
        Vector3 angle = new Vector3(0, 1, 0);
        transform.LookAt(playerTransform.position + angle);
    }
}
