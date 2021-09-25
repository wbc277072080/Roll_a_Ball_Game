using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    //referance for speed and size
    public float speed;
    public Vector3 size;

    //count and win text
    public Text countText;
    public Text winText;

    //all audio source
    public AudioSource increaseScore;
    public AudioSource decreaseScore;
    public AudioSource accelerate;
    public AudioSource slowdown;
    public AudioSource jumpSound;
    public AudioSource bigger;
    public AudioSource smaller;
    public AudioSource victory;
    public AudioSource fail;

    //physics
    private Rigidbody rb;
    private int count;

    //replay button
    public Button replay;

    void Start()
    {
        //init
        rb = GetComponent<Rigidbody>();  
        size = transform.GetComponent<Renderer>().bounds.size;
        speed = 10;
        count = 0;
        SetCountText();
        replay.gameObject.SetActive(false);
        winText.text = "";       
        
    }

    //update lost condition
    void Update()
    {
        if(transform.position.y < -30.0f){
            Fail();
        }
    }

    //move and jump
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float jump;
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            jumpSound.Play();
            jump = 25f;
        }
        else
        {
            jump = 0;
        }
        Vector3 movement = new Vector3(moveHorizontal,jump,moveVertical);
        rb.AddForce(movement * speed);
    }

    //pick up items
    void OnTriggerEnter(Collider other) {
        //add score
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            increaseScore.Play();
            count = count + 1;
            SetCountText();
        }

        //minus score
        if(other.gameObject.CompareTag("Decrease Score"))
        {
            other.gameObject.SetActive(false);
            decreaseScore.Play();
            count = count - 1;
            SetCountText();
        }

        //bigger
         if(other.gameObject.CompareTag("Bigger"))
        {
            other.gameObject.SetActive(false);
            bigger.Play();
            Vector3 biggerSize = new Vector3 (size.x * 2, size.y * 2, size.z * 2);
            transform.localScale = biggerSize;
            size = biggerSize;
        }

        //smaller
        if(other.gameObject.CompareTag("Smaller"))
        {
            other.gameObject.SetActive(false);
            smaller.Play();
            Vector3 smallerSize = new Vector3 (size.x * 0.6f, size.y * 0.6f, size.z * 0.6f);
            transform.localScale = smallerSize;
            size = smallerSize;
        }

        //accelerate
        if(other.gameObject.CompareTag("Accelerate"))
        {
            other.gameObject.SetActive(false);
            accelerate.Play();
            speed = speed * 1.5f;
        }

        //slowdown
        if(other.gameObject.CompareTag("Slowdown"))
        {
            other.gameObject.SetActive(false);
            slowdown.Play();
            speed = speed * 0.6f;
        }

        //final
        if(other.gameObject.CompareTag("Final"))
        {
            other.gameObject.SetActive(false);
            Final();
        }

    }

    //update count text
    void SetCountText()
    {
        countText.text = "Count: "+ count.ToString(); 
        
    }

    //win or lose when reach final
    void Final()
    {
        if(count >= 10){
            victory.Play();
            replay.gameObject.SetActive(true);
            winText.text = "You Win!";
        }
        else if(count < 10)
        {
            Fail();
        }
    }

    //lose
    void Fail()
    {   
        replay.gameObject.SetActive(true);
        fail.Play();
        winText.text = "You Failed!";
    }
}
