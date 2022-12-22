using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuController : MonoBehaviour
{
    public GameObject panelSettings;
    public Slider volumeSlider;
    public AudioSource BG_MenuAudio;
    
    void Start()
    {
        panelSettings = GameObject.FindGameObjectWithTag("PanelSettings");
        volumeSlider = GetComponentInChildren<Slider>();
        BG_MenuAudio = GetComponent<AudioSource>();

        panelSettings.SetActive(false);
    }
    
    void Update()
    {
        BG_MenuAudio.volume = volumeSlider.value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("City");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if(panelSettings.activeInHierarchy == false)
        {
            panelSettings.SetActive(true);
        }
        else
        {
            panelSettings.SetActive(false);
        }
    }
}
