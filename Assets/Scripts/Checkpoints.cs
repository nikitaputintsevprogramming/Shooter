using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    // Список наших чек-поинтов
    public GameObject LVL2;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject == LVL2)
        {
            EditorSceneManager.LoadScene("Mountains"); // 2            
        }
    }
}
