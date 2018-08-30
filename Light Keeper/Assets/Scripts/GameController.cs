using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private GameObject sun;

    private float timeSurvived = 0.0f;

    private int score = 0;

    [SerializeField]
    private Text timeUI;

    [SerializeField]
    private Text scoreUI;

    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

	void Start () {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Respawn")){
            spawnPoints.Add(g.GetComponent<SpawnPoint>());
        }

        StartCoroutine(FirstSpawn());
        
	}

    IEnumerator FirstSpawn()
    {
        
        yield return new WaitForSeconds(3f);
        foreach(SpawnPoint s in spawnPoints)
        {
            s.Spawn();
        }

    }
	
	void Update () {
        timeSurvived += Time.deltaTime;


        scoreUI.text = score + "";

        timeUI.text =  ((int) timeSurvived / 60) .ToString();
        timeUI.text += "." + (timeSurvived % 60).ToString("f2");
	}
}
