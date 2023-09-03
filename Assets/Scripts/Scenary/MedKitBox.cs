using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.healthKitAmount += 1;
            gameObject.SetActive(false);
        }
    }
}
