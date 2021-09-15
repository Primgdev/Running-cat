using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    public Animator animator;
    public float speed;
    private Vector3 move;
    private CharacterController controller;
    private float animationTime = 3.0f;
    private float verticalvelo = 0.0f;
    private float gravity = 14.0f;

    public float jumpForce;
    public Rigidbody rigi;
    private AudioSource music;
    private AudioSource jumpSound;
    AudioSource pickup;
    AudioSource fisheat;
   
    public float speedUp;
    public float speedIncrease;
    private float speedMilestoneCount;
    public Text coincountText;
    public int coin;
    public int fish;
    public int health;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    
    public Text fishcountText;
    public CameraShake shake;






    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        fish = 0;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rigi = GetComponent<Rigidbody>();
        AudioSource[] audios = GetComponents<AudioSource>();
        music = audios[0];
        jumpSound = audios[1];
        pickup = audios[2];
        fisheat = audios[3];
        
        health = 3;

        //speedMilestoneCount = speedIncrease;

        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncrease;
            //speedIncrease = speedIncrease * speedUp;
            speed = speed * speedUp;
            print("speed up");
        }


        if (Time.time < animationTime)
        {


            controller.Move((Vector3.forward * speed) * Time.deltaTime);
            animator.SetTrigger("Run");
            return;
        }

        move = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalvelo -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {

                verticalvelo = jumpForce;
                animator.SetTrigger("Jump");
                jumpSound.Play();

                print("working");
            }
        }
        else
        {
            verticalvelo -= gravity * Time.deltaTime;
        }

        move.x = Input.GetAxisRaw("Horizontal") * speed;

        move.y = verticalvelo;
        move.z = speed;

        controller.Move(move * Time.deltaTime);





    }



    public void Coin()
    {
        print(" coin recieved");
        coin += 1;

        pickup.Play();
        coincountText.text = "" + coin.ToString();
        StartCoroutine(shake.Shake(.0010f, .4f));
        print("camera shaked");

    }
    public void Fish()
    {
        print(" fish recieved");
        fish += 1;
        fisheat.Play();

        fishcountText.text = "" + fish.ToString();
        StartCoroutine(shake.Shake(.0010f, .4f));
        print("camera shaked");

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            speed -= 1;
            print("collide and speed down");
            health -= 1;
            print("health degrade");
            StartCoroutine(shake.Shake(.0010f, .4f));
            

            if (health == 3)
            {
                
                heart3.SetActive(true);
                heart2.SetActive(true);
                heart1.SetActive(true);
            }

            if (health == 2)
            {
                
                heart3.SetActive(false);
                heart2.SetActive(true);
                heart1.SetActive(true);
            }

            if (health == 1)
            {
                
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(true);
            }

            if (health == 0)
            {
                
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);




                print("dead");
                SceneManager.LoadScene(2);
            }
            
        }
        
    }
    public void Health()
    {
        print(" hey I got health...........YAY");
        health += 1;
       
       
        if (health == 3)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }

        if (health == 2)
        {
            heart3.SetActive(false);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }

        if (health == 1)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(true);
        }

        if (health == 0)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(false);


        }

    }
}

    
