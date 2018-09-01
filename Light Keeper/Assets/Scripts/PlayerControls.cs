using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private float shootBombDelay;

    [SerializeField]
    private int bombs;

    [SerializeField]
    private Text bombsUI;

    private float nextShoot = 0;
    private float nextBombShoot = 0;

    [SerializeField]
    private GameObject shoot;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject shield;

    private bool shieldActive = false;

    private AudioSource[] audioSrcs;



    void Start () {
        audioSrcs = GetComponents<AudioSource>();
    }


    void Update () {
        bombsUI.text = bombs + "";
        ShootBomb();

        Shoot();


        Shield();
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.L) && Time.time > nextShoot && !shieldActive)
        {
            audioSrcs[2].Play();
            nextShoot = Time.time + shootDelay;
            Instantiate(shoot, transform.position, transform.rotation);

        }
    }

    void Shield()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            shieldActive = true;
            shield.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            shieldActive = false;
            shield.SetActive(false);
        }

    }

    void ShootBomb()
    {
        if (Input.GetKey(KeyCode.M) && Time.time > nextBombShoot && bombs > 0 && !shieldActive)
        {
            nextBombShoot = Time.time + shootBombDelay;
            Instantiate(bomb, transform.position, transform.rotation);
            bombs -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BombPowerUp")
        {
            bombs += 1;
            Destroy(collision.gameObject);
        }
    }
}
