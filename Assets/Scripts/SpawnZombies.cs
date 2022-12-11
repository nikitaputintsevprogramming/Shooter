using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{    
    public Waves _waves;

    public GameObject YakuZombie;
    public float SpawnTime;
    public float minSpawnTime = 5f; 
    public float maxSpawnTime = 15f;     

    void Start()
    {        
        _waves = FindObjectOfType<Waves>();

        YakuZombie = Resources.Load("Prefabs/YakuZombie") as GameObject;
        StartCoroutine("WaitTimeForSpawn");
    }

    IEnumerator WaitTimeForSpawn()
    {                
        while(true)
        {      
            if(_waves.ZombieCount.Length < _waves.maxZombiesOnWave)
            {
                Instantiate(YakuZombie.gameObject, gameObject.transform.position, Quaternion.identity);
                SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(SpawnTime); 
            }   
            else
            {
                yield return new WaitForSeconds(SpawnTime); 
            }                                                      
        }
    }
}
