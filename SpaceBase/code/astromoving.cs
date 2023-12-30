using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astromoving : MonoBehaviour
{
    // Start is called before the first frame update
    float hinput;
    float vinput;
    public float speed = 0.04f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        hinput = Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");

        if (vinput > 0)
        {
            transform.position += transform.forward *speed;
            anim.SetBool("isRunning", true);
        }
        if (vinput < 0)
        {
            transform.position -= transform.forward *speed;
            anim.SetBool("isRunning", true);
        }
        if (vinput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        if (hinput > 0)
        {
            transform.Rotate(0, 1f, 0, Space.Self);
            anim.SetBool("isRight", true);
        }
        if (hinput < 0)
        {
            transform.Rotate(0, -1f, 0, Space.Self);
            anim.SetBool("isLeft", true);
        }
        if (hinput == 0)
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

}
