using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject YakuZombie;
    public float SpawnTime = 5f;

    void Start()
    {
        StartCoroutine("WaitTimeForSpawn");
    }

    IEnumerator WaitTimeForSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnTime);
            Instantiate(YakuZombie.gameObject, gameObject.transform.position, Quaternion.identity);
        }
    }
}
