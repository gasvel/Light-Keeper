using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rigi;

    private Vector2 moveDir;

    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private int bombs;

    [SerializeField]
    private GameObject sprite;

    [SerializeField]
    private float rotSpeed;

	void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        Vector2 newPos = rigi.position + moveDir * Time.fixedDeltaTime;
        rigi.MovePosition(newPos);


	}

    private void Update()
    {
        float movHor = Input.GetAxisRaw("Horizontal");
        float movVer = Input.GetAxisRaw("Vertical");

        //Smooth version
        //Vector2 mov = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        //Robotic version
        Vector2 mov = new Vector2(movHor,movVer);

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

    void Shoot()
    {

    }

    void ShootBomb()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
