using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleImpact : MonoBehaviour
{
    public GameObject bloodEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyController>().currentState != EnemiesState.dying)
            {
                other.gameObject.GetComponent<EnemySounds>().ImpactSound();
                GameObject newBlood = Instantiate(bloodEffect, other.transform.position + other.transform.forward * 1, other.transform.rotation);
                other.gameObject.GetComponent<EnemyController>().health -= 2;
                Destroy(newBlood, 1);
            }
        }
    }
}
