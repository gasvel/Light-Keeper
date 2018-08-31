using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private Rigidbody2D rigi;

    private GameObject sun;

    [SerializeField]
    private float speed;
  

    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        sun = GameObject.FindGameObjectWithTag("Sun");
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, sun.transform.position, step);
    }
}
