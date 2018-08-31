using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy1 : MonoBehaviour {

    private Rigidbody2D rigi;

    private GameObject sun;

    [SerializeField]
    private GameObject shoot;

    private SpawnPoint spPoint;

    private Animator anim;

    private AudioSource audioSrc;

    private bool attPosReached = false;

    private Vector3 spawnPos;
    private bool attacking = true;
    private bool retPosReached = false;
    private bool retiring = false;

    private GameController game;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float scorePoints;

    [SerializeField]
    private float distanceSP;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        audioSrc = GetComponent<AudioSource>();
        sun = GameObject.FindGameObjectWithTag("Sun");
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

	}

    private IEnumerator ChangeToRetire()
    {
        rigi.velocity = Vector2.zero;
        float secs = UnityEngine.Random.Range(2f, 4f);
        yield return new WaitForSeconds(secs);
        retiring = true;
        
    }

    private IEnumerator ChangeToAttack()
    {

        rigi.velocity = Vector2.zero;
        float secs2 = UnityEngine.Random.Range(0.5f, 3.5f);
        yield return new WaitForSeconds(secs2);
        attacking = true;
    }

    void Shoot()
    {
        Instantiate(shoot, transform.position, transform.rotation);
    }

    internal void SetSpawnPos(Vector3 position)
    {
        spawnPos = position;
    }

     void Update()
     {
         if (!attPosReached && attacking)
         {
             AttackMovement();
         }
        else if (attPosReached && attacking)
        {
            Shoot();
            attacking = false;
            attPosReached = false;
            StartCoroutine(ChangeToRetire());
        }

        if(!retPosReached && retiring)
        {
            RetireMovement();
        }
        else if (retPosReached && retiring)
        {
            retiring = false;
            retPosReached = false;
            StartCoroutine(ChangeToAttack());
        }
     }

    internal void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        spPoint = spawnPoint;
    }

    void AttackMovement()
    {
        Vector2 direction = ((Vector2)sun.transform.position) - rigi.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigi.angularVelocity = -rotateAmount * rotSpeed;
        rigi.velocity = transform.up * speed;
        if( Vector3.Distance(transform.position, (Vector2)sun.transform.position) < distance)
        {
            attPosReached = true;
        }
        

    }

    void RetireMovement()
    {
        Vector2 direction = ((Vector2)spawnPos) - rigi.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigi.angularVelocity = -rotateAmount * rotSpeed;
        rigi.velocity = transform.up * speed;
        retPosReached = Vector3.Distance(transform.position, (Vector2)spawnPos) < distanceSP;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShoot")
        {
            game.AddScore(scorePoints);
            StartCoroutine(Explode());

        }
    }

    private IEnumerator Explode()
    {
        attacking = false; retiring = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        rigi.velocity = Vector2.zero;
        anim.SetTrigger("Explode");
        audioSrc.Play();
        yield return new WaitForSeconds(0.8f);
        spPoint.Respawn();
        Destroy(this.gameObject);
    }




}
