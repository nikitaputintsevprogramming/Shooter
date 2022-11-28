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

    // Перемнные для очереди стрельбы
    public float FireRate = 1f;
    public float NextTimeToFire = 0f;

    void Update()
    {    
        if(Input.GetMouseButtonDown(0) && Time.time >= NextTimeToFire)
        {
            Shoot();
            NextTimeToFire = Time.time + FireRate; // 1f/FireRate
            print(NextTimeToFire);
        }
    }

    void Shoot()
    {
        ShootEffect.Play();
        ShootAudio.Play();

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(MarkDamage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            ParticleSystem CreateHit = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(CreateHit.gameObject, 1f);
        }
    }
}
