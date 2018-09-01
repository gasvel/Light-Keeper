using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private AudioSource audioSrc;


	void Start () {
        audioSrc = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShoot")
        {
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            audioSrc.Play();

        }
    }
}
