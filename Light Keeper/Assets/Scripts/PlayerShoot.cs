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


}
