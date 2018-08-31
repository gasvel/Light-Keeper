using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy1 : MonoBehaviour {

    private Rigidbody2D rigi;

    private GameObject sun;

    private SpawnPoint spPoint;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private float distance;

    public bool attPosReached = false;

    public Vector3 spawnPos;
    public bool attacking = true;
    public bool retPosReached = false;
    public bool retiring = false;

    [SerializeField]
    private float distanceSP;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        sun = GameObject.FindGameObjectWithTag("Sun");

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
            spPoint.Respawn();
            Destroy(this.gameObject);
        }
    }


}
