using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameControl : MonoBehaviour
{
    public Button backButton;
    

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(()=>{
            SceneManager.LoadScene("MainScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.name == "rocketConsole"){
            StartCoroutine(LoadSceneWithDelay("BuildRocket"));
        }
        if(col.gameObject.name == "memoryConsole"){
            StartCoroutine(LoadSceneWithDelay("MemoryPuzzle"));
        }
        if(col.gameObject.name == "decodeConsole"){
            StartCoroutine(LoadSceneWithDelay("DecodeWord"));
        }
        if(col.gameObject.name == "pipeConsole"){
            StartCoroutine(LoadSceneWithDelay("PipeConnect"));
        }
        if(col.gameObject.name == "endBulletin"){
            StartCoroutine(LoadSceneWithDelay("EndScene")); 
        }
    }
    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(1.0f);

        // Load the scene after the delay
        SceneManager.LoadScene(sceneName);
    }
}
