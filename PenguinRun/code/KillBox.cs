using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    public Canvas restartScreen;
    public GameController gameController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Invoke("RestartGameScreen", 0.2f);
        }
    }

    private void RestartGameScreen()
    {
        restartScreen.gameObject.SetActive(true); 
        Time.timeScale = 0; 
    }

}
