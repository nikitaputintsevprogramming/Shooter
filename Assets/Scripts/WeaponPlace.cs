using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlace : MonoBehaviour
{
    public GameObject[] WeaponBag;
    public int WeaponBagLength;
    public GameObject CurrentWeapon;

    void Start()
    {
        WeaponBagLength = transform.childCount;
        WeaponBag = new GameObject[WeaponBagLength];

        for (int i = 0; i < WeaponBagLength; i++)
        {
            WeaponBag[i] = transform.GetChild(i).gameObject;
        }

        CurrentWeapon = WeaponBag[0];
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            CurrentWeapon = WeaponBag[0];
            ChooseWeapon();
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            CurrentWeapon = WeaponBag[1];
            ChooseWeapon();
        }
    }

    void ChooseWeapon()
    {
        for (int i = 0; i < WeaponBagLength; i++)
        {
            if(WeaponBag[i] != CurrentWeapon)
            {
                WeaponBag[i].gameObject.SetActive(false);
            }
            else
            {
                WeaponBag[i].gameObject.SetActive(true);
            }
        }
    }
}
