using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBackgroundMusic : MonoBehaviour
{

    private AudioSource backgroundSound;

    public MovePenguin mp;
    

    // Start is called before the first frame update
    void Start()
    {
         backgroundSound = GetComponent<AudioSource>();
         
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M)){
            backgroundSound.mute = !backgroundSound.mute;
        }

        if(mp.MetBaby){
            backgroundSound.Stop();
        }
    }
}
