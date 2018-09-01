using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private float shootBombDelay;

    [SerializeField]
    private int bombs;

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
}
