using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PipeGameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    public TMP_Text finishedtext;
    public Button backbutton;
    public GameObject panel; 
     
    public int totalPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes];
        for (int i = 0; i < Pipes.Length; i++){
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int totalCorrect = 0;
        foreach (GameObject pipe in Pipes){
            if(pipe.GetComponent<PipeScript>().GetIsPlaced()){
                totalCorrect++;
            }
        }
        if(totalCorrect == totalPipes){
            Invoke("backScreen", 1f);
            
        }
    }

    void backScreen(){
        finishedtext.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
