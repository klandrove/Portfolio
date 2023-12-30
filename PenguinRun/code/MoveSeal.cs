using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSeal : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 3.0f;
    public float originalX;

    private bool movingRight = true;
    private Vector3 startPosition;

    void Start()
    {
        originalX = transform.position.x;
        startPosition = transform.position;
    }

    void Update()
    {
        float newX = originalX + distance * Mathf.Sin(Time.time * speed);

        if (newX < transform.position.x && !movingRight)
        {
            FlipSprite();
            movingRight = true;
        }
        else if (newX > transform.position.x && movingRight)
        {
            FlipSprite();
            movingRight = false;
        }

        transform.position = new Vector2(newX, transform.position.y);
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

