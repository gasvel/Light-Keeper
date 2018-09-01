using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

    private GameObject sun;

    [SerializeField]
    private AudioClip gameOverTheme;

    private AudioSource audioSrc;

    private float timeSurvived = 0.0f;

    private float score = 0;

    private bool started = false;

    public float difficulty = 0;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Text survivedTimeUI;

    [SerializeField]
    private Text timeUI;

    [SerializeField]
    private Text scoreUI;

    [SerializeField]
    private GameObject startText;

    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private float lapse = 25;

    void Start () {
        audioSrc = GetComponent<AudioSource>();
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Respawn")){
            spawnPoints.Add(g.GetComponent<SpawnPoint>());
        }

        StartCoroutine(FirstSpawn());
        
	}

    IEnumerator FirstSpawn()
    {
        yield return new WaitForSeconds(1.5f);
        startText.SetActive(true);
        yield return new WaitForSeconds(1f);
        startText.SetActive(false);
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
        audioSrc.clip = gameOverTheme;
        audioSrc.Play();
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

            if ((timeSurvived % 60) > lapse)
            {
                difficulty += 1;
                if (lapse < 60)
                {
                    lapse += 3;
                }
            }
        }

	}

    public void AddScore(float scorePoints)
    {
        score += scorePoints;
    }
}
