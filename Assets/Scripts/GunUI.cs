using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    private Gun gun;

    public Text[] textAmmo;

    void Start()
    {
        gun = FindObjectOfType<Gun>();

        textAmmo = gameObject.GetComponentsInChildren<Text>();    

    }
    
    void Update()
    {
        PistolUI();
    }

    void PistolUI()
    {
        textAmmo[0].text = "Bag Ammo: " +  gun.BagAmmo;
        textAmmo[1].text = "Max Ammo: " + gun.maxAmmo; 
        textAmmo[2].text = "Current Ammo: " + gun.currentAmmo;
    }
}
