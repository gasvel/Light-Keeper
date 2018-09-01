using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rigi;

    private Animator anim;

    private AudioSource[] audioSrcs;

    private Vector2 moveDir;

    private GameController game;

    private bool rigiActive = true;


    [SerializeField]
    private float movSpeed;




    [SerializeField]
    private float rotSpeed;


    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        audioSrcs = GetComponents<AudioSource>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

    internal void Die()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        rigiActive = false;
        audioSrcs[0].Play();
        anim.SetTrigger("GameOver");
        yield return new WaitForSeconds(2f);
        game.GameOver();
        Destroy(this.gameObject);
    }

    void FixedUpdate () {
        Vector2 newPos = rigi.position + moveDir * Time.fixedDeltaTime;
        if (rigiActive)
        {
            rigi.MovePosition(newPos);

        }


    }

    private void Update()
    {
        float movHor = Input.GetAxisRaw("Horizontal");
        float movVer = Input.GetAxisRaw("Vertical");

       
        //Smooth version
        //Vector2 mov = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        //Robotic version
        Vector2 mov = new Vector2(movHor,movVer);

        if((movVer != 0 || movHor != 0) && !anim.GetBool("Boosting"))
        {
            anim.SetBool("Boosting", true);
            audioSrcs[1].Play();
        }
        else if (movVer == 0 || movHor == 0 && anim.GetBool("Boosting"))
        {
            anim.SetBool("Boosting", false);
            audioSrcs[1].Stop();
        }

        moveDir = mov * movSpeed;
        HandleRotation(movHor, movVer);


    }

    void HandleRotation(float x, float y)
    {


        if(x>0)
        {
            if(y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -45), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -125), rotSpeed * Time.deltaTime);
            }
            else
            {
               
                transform.rotation = Quaternion.Slerp(transform.rotation ,Quaternion.Euler(0, 0, -90),rotSpeed* Time.deltaTime);
            }
        }
        else if(x<0)
        {
            if (y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 45), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 125), rotSpeed * Time.deltaTime);
            }
            else
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), rotSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotSpeed * Time.deltaTime);
            }

        }
        
    }






}
