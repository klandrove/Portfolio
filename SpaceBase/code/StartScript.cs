using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(()=>{
            SceneManager.LoadScene("MainScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
