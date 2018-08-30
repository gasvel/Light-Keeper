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

    private IEnumerator RandomSpawn()
    {
        float secs = UnityEngine.Random.Range(0,2f);
        yield return new WaitForSeconds(secs);
        GameObject.Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0));
    }
}
