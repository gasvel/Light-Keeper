using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Slider healthBar;

    void Start () {
        spriteRend = GetComponent<SpriteRenderer>();
	}

    void Update() {
        transform.Rotate(new Vector3(0, 0, rotSpeed));

        healthBar.value = healthPoints;

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

        if (collision.gameObject.tag == "Bomb" && healthPoints <= 90)
        {
            healthPoints += collision.gameObject.GetComponent<Bomb>().healthPoints;
        }
    }

    public void ApplyDamage(float damage)
    {
        healthPoints -= damage;
    }
}
