using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint2 : MonoBehaviour {

    private GameController game;

    [SerializeField]
    private GameObject enemy2;

    [SerializeField]
    private float minLvl;

    [SerializeField]
    private float maxLvl;

    void Start () {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	void Update () {
        float lvl = Mathf.Floor( UnityEngine.Random.Range(minLvl, maxLvl));

        if(lvl == game.difficulty)
        {
            float diff = maxLvl - minLvl;
            minLvl = lvl + 2;
            maxLvl = minLvl + diff;
            Instantiate(enemy2, transform.position, new Quaternion(0, 0, 0, 0));
        }
	}
}
