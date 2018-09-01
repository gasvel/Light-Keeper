using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {


    public Player parent;

	void Start () {
        parent = GetComponentInParent<Player>();
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Sun" || collision.gameObject.tag == "EnemyShoot")
        {
            parent.Die();


        }
    }
}
