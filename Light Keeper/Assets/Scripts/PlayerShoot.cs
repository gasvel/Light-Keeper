using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShoot : MonoBehaviour {

    private Rigidbody2D rigi;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float scopeLenght;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyOnScopeReached());
	}
	
	void Update () {

        rigi.velocity = transform.up * speed;

	}

    IEnumerator DestroyOnScopeReached()
    {
        yield return new WaitForSeconds(scopeLenght);
        Destroy(this.gameObject);
    }

<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
=======
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

>>>>>>> d93bb670ede800c8addd58125516fe5b0f964394

}
