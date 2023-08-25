using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMeleImpact : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("LE DIO PLAYER");
        }
    }
}
