using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePenguin : MonoBehaviour
{
    public float maxSpeed = 10.0f;

    private Animator anim;
    Rigidbody2D rb;

    public float JumpForce;
    float move;
    bool Grounded = true;
    const string IS_GROUNDED = "IsGrounded";

    const string CLICKED_RIGHT = "RightClick";

    public bool MetBaby = false;
    const string MET_BABY = "MetTheBaby";
    
    bool facingRight = true;

    public AudioSource[] sounds;

    public Canvas restartScreen;

    public GameObject spawner;
    bool gameActive;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sounds = GetComponents<AudioSource>();
        gameActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       move = Input.GetAxis("Horizontal");

       anim.SetFloat("Speed", Mathf.Abs(move));
       rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);


    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded == true){
            rb.AddForce(transform.up * JumpForce);
            Grounded = false;
            anim.SetBool(IS_GROUNDED, false); 
       } 

       if(Grounded == true){
            anim.SetBool(IS_GROUNDED, true);
       }
       
       if(Input.GetMouseButtonDown(1) && (gameActive == true))
       {
          anim.SetTrigger(CLICKED_RIGHT);
          sounds[1].Play();
       }
        
        if(MetBaby==true){
            anim.SetTrigger(MET_BABY);
            maxSpeed = 0.0f;
            JumpForce = 0.0f;
            spawner.GetComponent<IcicleSpawner>().spawnInterval = 0;
            gameActive = false;
        }

        if(move > 0 && !facingRight){
            Flip();
        }
        else if(move < 0 && facingRight){
            Flip();
        }
    }
    
    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.tag == "Ground"){
            Grounded = true;
            if (sounds[0].isPlaying == false){
                sounds[0].Play();
            }
        }
        if(Col.gameObject.tag == "Baby"){
            MetBaby = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            sounds[2].Play();
        }
        if (collision.CompareTag("KillBox"))
        {
            sounds[3].Play();
        }
        if (collision.CompareTag("icicle") && (gameActive == true))
        {
            Invoke("RestartScene", 0.2f);
            sounds[3].Play();
        }
    }


     private void RestartScene()
    {
        restartScreen.gameObject.SetActive(true);
        Time.timeScale = 0; 
    }

    

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

 
}

