using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipeScript : MonoBehaviour
{
    float[] rotations = {0, 90, 180, 270};
    Button button;

    public float[] correctRotation;
    public bool isPlaced = false;

    int PossibleRots = 1;
    // Start is called before the first frame update
    private void Start()
    {
        PossibleRots = correctRotation.Length;
        button = GetComponent<Button>();
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0,0, rotations[rand]);

        if(PossibleRots > 1){
            if(transform.eulerAngles.z == correctRotation[0] ||transform.eulerAngles.z == correctRotation[1])
            {
            isPlaced = true;
            }
        }else {
            if(transform.eulerAngles.z == correctRotation[0]){
                isPlaced = true;
            }
        }

        button.onClick.AddListener(()=>{
            transform.Rotate(new Vector3(0,0,90));
            if(PossibleRots > 1){
                if((int)transform.eulerAngles.z == correctRotation[0] || (int)transform.eulerAngles.z == correctRotation[1]){
                    isPlaced = true;
                }else if(isPlaced == true){
                    isPlaced = false;
                }
            } else{
                if((int)transform.eulerAngles.z == correctRotation[0]){
                    isPlaced = true;
                }else if(isPlaced == true){
                    isPlaced = false;
                }
            }
        });
    }
    public bool GetIsPlaced() {
         return isPlaced;
    }
}
