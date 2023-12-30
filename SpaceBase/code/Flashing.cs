using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public Color32 newcolor;
    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flash());
    }

    // Update is called once per frame
    IEnumerator flash()
    {   
        //int count = 100;
        while(!won){
            GetComponent<Image>().color = newcolor;
            yield return new WaitForSeconds(0.5f);
            GetComponent<Image>().color = new Color32(255,255,255,255);
            yield return new WaitForSeconds(0.5f);
            //count--;
        }
    }
}
