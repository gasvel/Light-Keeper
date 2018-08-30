using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy1 : MonoBehaviour {

    private Rigidbody2D rigi;

    private GameObject sun;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private Vector2 objDistance;

	void Start () {
        rigi = GetComponent<Rigidbody2D>();
        sun = GameObject.FindGameObjectWithTag("Sun");
        Debug.Log((Vector2)sun.transform.position - objDistance);
	}
	
	void Update () {
        Vector2 direction = ((Vector2)sun.transform.position - objDistance) - rigi.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigi.angularVelocity = -rotateAmount * rotSpeed;
        if (Vector3.Distance(transform.position, (Vector2)sun.transform.position - objDistance) > 0.5f )
        {

            rigi.velocity = transform.up * speed;
        }
        else
        {
            rigi.velocity = Vector2.zero;
        }
        
	}

    public void SetObjDistance(Vector2 dist)
    {
        objDistance = dist;
    }
}
