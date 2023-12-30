using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDisco : MonoBehaviour
{

    private AudioSource DiscoSound; 
    // Start is called before the first frame update
    void Start()
    {
        DiscoSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.tag == "Player"){
            DiscoSound.Play();
        }
        Invoke("RestartScreen", 5.0f);
    }

    void RestartScreen()
    {
        SceneManager.LoadScene(1);
    }
}
