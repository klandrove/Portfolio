using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Decode : MonoBehaviour
{
    string[] words = {"galaxy", "nebula", "planet", "comet", "asteroid", "spaceship", "celestial", "cosmos"};
    public TMP_Text codedWord;
    public TMP_InputField answer;
    public Button submit;
    public TMP_Text finishedtext;
    public Button backbutton;
    public GameObject panel;
    public TMP_Text wrongtext;
    // Start is called before the first frame update
    void Start()
    {
        codedWord.text = words[Random.Range(0, words.Length)];
        submit.onClick.AddListener(()=>{
            if(answer.text.ToLower() == codedWord.text){
                wrongtext.gameObject.SetActive(false);
                Invoke("endScreen", 0.5f);
            }
            else{
                wrongtext.gameObject.SetActive(true);
            }
        });
    }

    // Update is called once per frame
    void endScreen()
    {
        finishedtext.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
