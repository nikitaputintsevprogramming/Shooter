using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{    
    private Slider slider;

    public int playerHealth = 100;
    
    void Start()
    {
        slider = FindObjectOfType<Slider>();
    }

    void Update()
    {
        slider.value = playerHealth;
        Death();
    }

    public void TakePlayerDamage(int PlayerDamage)
    {
        playerHealth = playerHealth - PlayerDamage;
    }

    void Death()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
