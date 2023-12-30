using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class memorygame : MonoBehaviour
{
    public Button[] blocks = new Button[12];
    GameObject firstguess;
    GameObject secondguess;
    string firstanswer = "";
    string secondanswer = "";
    public int score = 0;
    public TMP_Text scorebox;
    public TMP_Text finishedtext;
    public Button backbutton;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(firstguess);
        AddListeners();
    }

    void Update(){
        if(score == 6){
            finishedtext.gameObject.SetActive(true);
            backbutton.gameObject.SetActive(true);
            panel.SetActive(true);
        }
    }

    // Update is called once per frame
    void AddListeners()
    {
        foreach (Button btn in blocks){
            btn.onClick.AddListener(()=> PickAPuzzle());
        }
    }

    public void PickAPuzzle(){
        if(firstguess == null){
            firstguess = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            firstanswer = firstguess.transform.GetChild(0).gameObject.name;
            firstguess.transform.GetChild(0).gameObject.SetActive(true);
        } else if (secondguess == null){
            secondguess = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            secondanswer = secondguess.transform.GetChild(0).gameObject.name;
            secondguess.transform.GetChild(0).gameObject.SetActive(true);
        } else{
            firstguess = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            firstanswer = firstguess.transform.GetChild(0).gameObject.name;
            firstguess.transform.GetChild(0).gameObject.SetActive(true);
            secondguess = null;
        }
        if (firstguess != null && secondguess != null){
            foreach (Button btn in blocks){
                btn.enabled = false;
            }
            Invoke("CheckAnswer", 2.0f);
        }
       
        
    }

    public void CheckAnswer(){
        foreach (Button btn in blocks){
            if(btn.name != "correct"){
                btn.enabled = true;
            }
        }
        
        if (firstanswer == secondanswer){
            Debug.Log("CORRECT");
            score++;
            scorebox.text = "Score: " + score;
            GameObject.Find(firstguess.name).GetComponent<Button>().enabled = false;
            GameObject.Find(secondguess.name).GetComponent<Button>().enabled = false;
            GameObject.Find(firstguess.name).GetComponent<Button>().name = "correct";
            GameObject.Find(secondguess.name).GetComponent<Button>().name = "correct";
        } else {
            Debug.Log("WRONG");
            firstguess.transform.GetChild(0).gameObject.SetActive(false);
            secondguess.transform.GetChild(0).gameObject.SetActive(false);
        }
        
        
    }
}

