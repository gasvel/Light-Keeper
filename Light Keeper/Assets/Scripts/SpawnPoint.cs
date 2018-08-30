using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Vector2 objDistance;

	void Start () {
        Enemy1 enem = enemy.GetComponent<Enemy1>();
        enem.SetObjDistance(objDistance);
	}
	
	void Update () {
		
	}

    public void Spawn()
    {
        GameObject.Instantiate(enemy, transform);
    }
}
