using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{    
    public Waves _waves;

    private GameObject Player;
    private GameObject AmmoBox;

    public float ZombieSpeed = 0.5f;

    public int ZombieHealth = 100;
    public int DamageOfZombie = 10;

    public List<Rigidbody> GetRigidbodies = new List<Rigidbody>();

    private Animator ZombieAnimator;
    private AnimatorStateInfo ZombieStateInfo;

    void Start()
    {        
        _waves = FindObjectOfType<Waves>();

        ZombieAnimator = gameObject.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        AmmoBox = Resources.Load("Prefabs/PistolAmmo_Box") as GameObject;

        RigidbodyIsKinematicOn();
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        ZombieSpeed = 0.5f;
        ZombieHealth = ZombieHealth + _waves.ZombieHealthAdding;
        DamageOfZombie = DamageOfZombie + _waves.ZombieDamageAdding;
    }

    void Update()
    {
        ZombieController();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            ZombieAnimator.SetBool("Attack", true);

            other.gameObject.GetComponent<PlayerHealth>().TakePlayerDamage(DamageOfZombie);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            ZombieAnimator.SetBool("Attack", false);
        }
    }

    void RigidbodyIsKinematicOn()
    {        
        ZombieAnimator.enabled = true;

        for (int countHips = 0; countHips < GetRigidbodies.Count; countHips++)
        {
            GetRigidbodies[countHips].isKinematic = true;
        }
    }

    void RigidbodyIsKinematicOff()
    {
        ZombieAnimator.enabled = false;

        for (int countHips = 0; countHips < GetRigidbodies.Count; countHips++)
        {
            GetRigidbodies[countHips].isKinematic = false;
        }
    }

    void ZombieController()
    {
        
        
        ZombieStateInfo = ZombieAnimator.GetCurrentAnimatorStateInfo(0);

        if(ZombieHealth > 0)
        {
                if(ZombieStateInfo.IsName("Zombie Attack") || ZombieStateInfo.IsName("Zombie Biting"))
                {
                    ZombieSpeed = 0;
                }

                else
                {
                    ZombieSpeed = 0.5f;
                    gameObject.transform.LookAt(Player.transform.position);
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, ZombieSpeed * Time.deltaTime);
                }
        }       
    }

    public void TakeDamage(int damage)
    {
        ZombieHealth = ZombieHealth - damage;
        ZombieAnimator.SetTrigger("Hit");

        if(ZombieHealth <= 0)
        {
            RigidbodyIsKinematicOff();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;

            Instantiate(AmmoBox.gameObject, gameObject.transform.position, Quaternion.identity); 

            _waves.ZombieKillsOnWave++;
        }
    }
}
