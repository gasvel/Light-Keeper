using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    private SpriteRenderer spriteRend;

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
        spriteRend = GetComponent<SpriteRenderer>();
	}

    void Update() {
        transform.Rotate(new Vector3(0, 0, rotSpeed));

        if (50 <healthPoints && healthPoints < 75 && spriteRend.sprite != sun_75)
        {
            spriteRend.sprite = sun_75;
        }
        else if(25 < healthPoints && healthPoints < 50 && spriteRend.sprite != sun_50)
        {
            spriteRend.sprite = sun_50;
        }
        else if(0 < healthPoints && healthPoints < 25 && spriteRend.sprite != sun_25)
        {
            spriteRend.sprite = sun_25;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyShoot")
        {
            healthPoints -= collision.gameObject.GetComponent<EnemyShoot>().damage;
        }
    }

    public void ApplyDamage(float damage)
    {
        healthPoints -= damage;
    }
}
