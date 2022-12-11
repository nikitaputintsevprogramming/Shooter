using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam ;

    public float range = 50;
    public float MarkDamage = 10;

    public ParticleSystem ShootEffect;
    public ParticleSystem HitEffect;
    public AudioSource ShootAudio;

    public float ImpactForce = 1000f;

    // Кол-во патронов
    public int BagAmmo = 10;
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    private bool isReloading = false;

    // Перемнные для очереди стрельбы
    public float FireRate = 1f;
    public float NextTimeToFire = 0f;

    public int ZombieDamage = 50;

    void Start()
    {
        StartCoroutine(Reload());
    }

    void Update()
    {    
        if(isReloading) //=== true
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetMouseButtonDown(0) && Time.time >= NextTimeToFire)
        {
            Shoot();
            NextTimeToFire = Time.time + FireRate; // 1f/FireRate
            print(NextTimeToFire);
        }
    }

    IEnumerator Reload()
    {
        if(BagAmmo > 0)
        {
            isReloading = true;

            Debug.Log("Reloading...");
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = maxAmmo;
            BagAmmo = BagAmmo - maxAmmo;

            isReloading = false;
        }        
    }

    void Shoot()
    {
        currentAmmo --;

        ShootEffect.Play();
        ShootAudio.Play();        

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name);

            Target target = hit.transform.GetComponent<Target>();
            ZombieMove zombieMove = hit.transform.GetComponent<ZombieMove>();

            if(target != null)
            {
                target.TakeDamage(MarkDamage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            if(zombieMove != null)
            {
                zombieMove.TakeDamage(ZombieDamage);
            }

            ParticleSystem CreateHit = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(CreateHit.gameObject, 1f);
        }
    }
}
