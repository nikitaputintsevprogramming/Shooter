using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    
    public Gun gun;    

    void Start()
    {
        gun = FindObjectOfType<Gun>();
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            gun.BagAmmo = gun.BagAmmo + 10;
            Destroy(gameObject);
        }
    }
}
