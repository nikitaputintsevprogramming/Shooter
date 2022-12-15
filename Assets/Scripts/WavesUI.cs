using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    public Waves _waves;

    public Text textWaves;
    
    void Start()
    {
        _waves = FindObjectOfType<Waves>();
        textWaves = gameObject.GetComponentInChildren<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        WavesUIPrint();
    }

    void WavesUIPrint()
    {
        textWaves.text = "Waves:" + " " + _waves.WavesCount;
    }
}
