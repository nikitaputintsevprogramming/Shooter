using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waves : MonoBehaviour
{
    public GameObject[] ZombieCount;    


    public int WavesCount = 1;

    public int maxZombiesOnWave = 10;
    public int ZombieKillsOnWave;

    public int ZombieHealthAdding;
    public int ZombieDamageAdding;

    void Update()
    {        
        if(ZombieKillsOnWave >= maxZombiesOnWave)
        {
            ChangeWave();
        }

        CountZombiesOfWave();
    }

    void CountZombiesOfWave()
    {
        ZombieCount = GameObject.FindGameObjectsWithTag("Zombie");
    }

    void ChangeWave()
    {
        maxZombiesOnWave++;
        ZombieKillsOnWave = 0;

        WavesCount++;

        ZombieHealthAdding = ZombieHealthAdding + 50;
        ZombieDamageAdding = ZombieDamageAdding + 5;

        for (int countZombies = 0; countZombies < ZombieCount.Length; countZombies++)
        {
            Destroy(ZombieCount[countZombies].gameObject);
        }
    }  
}
