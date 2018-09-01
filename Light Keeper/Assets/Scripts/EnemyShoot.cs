using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float damage;

    private Rigidbody2D rigi;

    [SerializeField]
    private float speed;

    private GameObject sun;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        sun = GameObject.FindGameObjectWithTag("Sun");
    }
	
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, sun.transform.position, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
