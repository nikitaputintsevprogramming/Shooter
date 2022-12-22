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
                yield return new WaitForSeconds(SpawnTime);         
                SpawnPlace = new Vector3(Random.Range(-15, 15), 10.6f, Random.Range(-7, 7));
                SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                Instantiate(YakuZombie, SpawnPlace, Quaternion.identity);
                
            }   
            else
            {
                yield return new WaitForSeconds(SpawnTime); 
            }                                                      
        }
    }
}
