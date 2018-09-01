using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;

    private float minRange = 0.8f;
    private float maxRange = 2f;

    private float minRespawnT = 4.5f;
    private float maxRespawnT = 6.5f;

    private float difficulty = 1;


    public void Spawn()
    {
        StartCoroutine(RandomSpawn());
    }

    public void Respawn()
    {
        DifLevlUp();
        StartCoroutine(RandomRespawn());
    }

    private void DifLevlUp()
    {
        if(minRespawnT > minRange)
        {
            difficulty += 1;
            minRespawnT -= 0.1f;
            maxRespawnT -= 0.1f;
        }

    }

    private IEnumerator RandomSpawn()
    {
        float secs = UnityEngine.Random.Range(0,5f);
        yield return new WaitForSeconds(secs);
        Enemy1 enem = GameObject.Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0)).GetComponent<Enemy1>();
        enem.SetSpawnPoint(this);
        enem.SetSpawnPos(transform.position);
    }

    private IEnumerator RandomRespawn()
    {
        float secs = UnityEngine.Random.Range(minRespawnT, maxRespawnT);
        yield return new WaitForSeconds(secs);
        Enemy1 enem = GameObject.Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0)).GetComponent<Enemy1>();
        enem.SetSpawnPoint(this);
        enem.SetSpawnPos(transform.position);
    }
}
