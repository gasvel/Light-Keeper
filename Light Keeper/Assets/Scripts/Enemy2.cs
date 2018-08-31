using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy2 : MonoBehaviour {

    private Rigidbody2D rigi;

    private GameObject sun;

    private Animator anim;

    private AudioSource audioSrc;

    private GameController game;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float scorePoints;
    private bool center = true;
    private bool right = false;
    private bool left= false;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        audioSrc = GetComponent<AudioSource>();
        sun = GameObject.FindGameObjectWithTag("Sun");
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    void Update()
    {
        if (center)
        {
            float posibility = UnityEngine.Random.Range(0, 100);
            Vector3 movChange = Vector3.zero;

            if (posibility > 90)
            {                
                center = false;
                right = true;
                StartCoroutine(ChangeMovement());
            }
            else if (posibility < 10)
            {
                center = false;
                left = true;
                StartCoroutine(ChangeMovement());

            }

            Vector2 direction = ((Vector2)sun.transform.position) - rigi.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up ).z;
            rigi.angularVelocity = -rotateAmount * rotSpeed;


            rigi.velocity = transform.up * speed;
        }
        else if (right)
        {
            Vector2 direction = ((Vector2)sun.transform.position) - rigi.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up ).z;
            rigi.angularVelocity = -rotateAmount * rotSpeed;


            rigi.velocity = (transform.up + transform.right) * speed;
        }
        else if (left)
        {
            Vector2 direction = ((Vector2)sun.transform.position) - rigi.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rigi.angularVelocity = -rotateAmount * rotSpeed;


            rigi.velocity = (transform.up - transform.right) * speed;
        }
    }

    private IEnumerator ChangeMovement()
    {

        yield return new WaitForSeconds(2f);
        center = true;
        left = false;
        right = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShoot")
        {
            game.AddScore(scorePoints);
            StartCoroutine(Explode());

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sun")
        {
            collision.gameObject.GetComponent<Sun>().ApplyDamage(damage);
        }
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        rigi.velocity = Vector2.zero;
        anim.SetTrigger("Explode");
        audioSrc.Play();
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
