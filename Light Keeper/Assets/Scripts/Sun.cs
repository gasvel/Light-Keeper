using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    [SerializeField]
    private float healthPoints;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private Sprite sun_75;

    [SerializeField]
    private Sprite sun_50;

    [SerializeField]
    private Sprite sun_25;

    void Start () {
		
	}
	
	void Update () {
        transform.Rotate(new Vector3(0,0, rotSpeed));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyShoot")
        {
            healthPoints -= collision.gameObject.GetComponent<EnemyShoot>().damage;
        }
    }
}
