using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

    private GameObject sun;

    private float timeSurvived = 0.0f;

    private float score = 0;

    private bool started = false;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Text survivedTimeUI;

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
        started = true;
        foreach(SpawnPoint s in spawnPoints)
        {
            s.Spawn();
        }

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        started = false;
        survivedTimeUI.text = ((int)timeSurvived / 60).ToString();
        survivedTimeUI.text += "." + (timeSurvived % 60).ToString("f2");
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);


    }
	
	void Update () {
        if (started)
        {
            timeSurvived += Time.deltaTime;


            scoreUI.text = score + "";

            timeUI.text = ((int)timeSurvived / 60).ToString();
            timeUI.text += "." + (timeSurvived % 60).ToString("f2");

            scoreUI.text = score + "";
        }

	}

    public void AddScore(float scorePoints)
    {
        score += scorePoints;
    }
}
