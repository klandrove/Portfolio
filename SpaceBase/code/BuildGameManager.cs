using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildGameManager : MonoBehaviour
{
    public GameObject ColorPieces;
    public GameObject[] correctpieces;
    public TMP_Text finishedtext;
    public Button backbutton;
    public GameObject panel; 
     
    public int totalPieces = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPieces = ColorPieces.transform.childCount;
        correctpieces = new GameObject[totalPieces];
        for (int i = 0; i < correctpieces.Length; i++){
            correctpieces[i] = ColorPieces.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int totalCorrect = 0;
        foreach (GameObject piece in correctpieces){
            if(piece.GetComponent<rocketbuild>().getIsCorrect()){
                totalCorrect++;
            }
        }
        if(totalCorrect == totalPieces){
            Invoke("backScreen", 1f);
            
        }
    }

    void backScreen(){
        finishedtext.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}


