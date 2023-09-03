using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupliesBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.bearTrapAmount += 1;
            gameObject.SetActive(false);
        }
    }
}
