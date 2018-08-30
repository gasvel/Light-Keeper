using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;




    public void Spawn()
    {
        StartCoroutine(RandomSpawn());
    }

    public void Respawn()
    {
        StartCoroutine(RandomRespawn());
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
        float secs = UnityEngine.Random.Range(2f, 5f);
        yield return new WaitForSeconds(secs);
        Enemy1 enem = GameObject.Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0)).GetComponent<Enemy1>();
        enem.SetSpawnPoint(this);
        enem.SetSpawnPos(transform.position);
    }
}
