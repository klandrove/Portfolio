using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IcicleControl : MonoBehaviour
{
    // public GameController gameController;
    // public Canvas restartScreen;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject, 0.5f);
        }
        if (collision.CompareTag("KillBox"))
        {
            Destroy(gameObject);
        }
    }

}
