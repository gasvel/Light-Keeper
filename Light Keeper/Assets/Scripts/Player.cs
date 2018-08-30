using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rigi;

    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private int bombs;

    [SerializeField]
    private GameObject sprite;

	void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        float horMov = Input.GetAxis("Horizontal");
        float verMov = Input.GetAxis("Vertical");

        Vector2 pos = new Vector2(horMov * movSpeed, verMov * movSpeed);


        pos *= Time.deltaTime;

        HandleRotation(horMov,verMov);
        transform.Translate(pos);

	}

    void HandleRotation(float x,float y)
    {

        

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
