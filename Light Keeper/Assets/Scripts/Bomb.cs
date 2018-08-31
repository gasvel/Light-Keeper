using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour {

    [SerializeField]
    internal float healthPoints;

    private Animator anim;

    private Rigidbody2D rigi;

    private GameObject sun;

    public float heal;

    [SerializeField]
    private float speed;
    private bool alive = true;

    void Start () {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        sun = GameObject.FindGameObjectWithTag("Sun");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector2 direction = ((Vector2)sun.transform.position) - rigi.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigi.angularVelocity = -rotateAmount * 350f;
        if (alive)
        {
            transform.position = Vector2.MoveTowards(transform.position, sun.transform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sun")
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        alive = false;
        anim.SetTrigger("Explode");
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
