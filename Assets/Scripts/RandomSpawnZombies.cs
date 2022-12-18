using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnZombies : MonoBehaviour
{    
    public Waves _waves;

    public GameObject YakuZombie;
    public float SpawnTime;
    public float minSpawnTime = 5f; 
    public float maxSpawnTime = 15f;   

    public Vector3 SpawnPlace;  

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
                SpawnPlace = new Vector3(Random.Range(-25, 25), 10.6f, Random.Range(-7, 7));
                SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                Instantiate(YakuZombie.gameObject, SpawnPlace, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime); 
            }   
            else
            {
                yield return new WaitForSeconds(SpawnTime); 
            }                                                      
        }
    }
}
