using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waves : MonoBehaviour
{
    public GameObject[] ZombieCount;    


    public int WavesCount = 1;

    public int maxZombiesOnWave = 10;
    public int ZombieKillsOnWave;

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

        for (int countZombies = 0; countZombies < ZombieCount.Length; countZombies++)
        {
            Destroy(ZombieCount[countZombies].gameObject);
        }
    }  
}
