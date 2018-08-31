using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rigi;

    private Animator anim;

    private AudioSource[] audioSrcs;

    private Vector2 moveDir;

    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private float shootBombDelay;

    [SerializeField]
    private int bombs;


    [SerializeField]
    private float rotSpeed;
    private float nextShoot = 0;
    private float nextBombShoot = 0;

    [SerializeField]
    private GameObject shoot;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject shield;

    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        audioSrcs = GetComponents<AudioSource>();
	}
	
	void FixedUpdate () {
        Vector2 newPos = rigi.position + moveDir * Time.fixedDeltaTime;
        rigi.MovePosition(newPos);


	}

    private void Update()
    {
        float movHor = Input.GetAxisRaw("Horizontal");
        float movVer = Input.GetAxisRaw("Vertical");

       
        //Smooth version
        //Vector2 mov = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        //Robotic version
        Vector2 mov = new Vector2(movHor,movVer);

        ShootBomb();

        Shoot();


        Shield();

        if((movVer != 0 || movHor != 0) && !anim.GetBool("Boosting"))
        {
            anim.SetBool("Boosting", true);
            audioSrcs[1].Play();
        }
        else if (movVer == 0 || movHor == 0 && anim.GetBool("Boosting"))
        {
            anim.SetBool("Boosting", false);
            audioSrcs[1].Stop();
        }

        moveDir = mov * movSpeed;
        HandleRotation(movHor, movVer);


    }

    void HandleRotation(float x, float y)
    {


        if(x>0)
        {
            if(y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -45), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -125), rotSpeed * Time.deltaTime);
            }
            else
            {
               
                transform.rotation = Quaternion.Slerp(transform.rotation ,Quaternion.Euler(0, 0, -90),rotSpeed* Time.deltaTime);
            }
        }
        else if(x<0)
        {
            if (y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 45), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 125), rotSpeed * Time.deltaTime);
            }
            else
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), rotSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (y>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotSpeed * Time.deltaTime);
            }
            else if (y<0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotSpeed * Time.deltaTime);
            }

        }
        
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.L) && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootDelay;
            Instantiate(shoot, transform.position, transform.rotation);

        }
    }

    void Shield()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            shield.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            shield.SetActive(false);
        }

    }

    void ShootBomb()
    {
        if (Input.GetKey(KeyCode.M) && Time.time > nextBombShoot && bombs > 0)
        {
            nextBombShoot = Time.time + shootBombDelay;
            Instantiate(bomb, transform.position, transform.rotation);
            bombs -= 1;
        }
    }

    IEnumerator GameOver()
    {
        audioSrcs[0].Play();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Sun")
        {
            StartCoroutine(GameOver());

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
