using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShoot : MonoBehaviour {

    private Rigidbody2D rigi;

    [SerializeField]
    private float speed;

	void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        rigi.velocity = transform.up * speed;
	}
}
