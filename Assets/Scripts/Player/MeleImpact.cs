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
            GameObject newBlood = Instantiate(bloodEffect, other.transform.position + other.transform.forward * 1, other.transform.rotation);
            other.gameObject.GetComponent<Enemy1State>().health = other.gameObject.GetComponent<Enemy1State>().health - 2;
            Destroy(newBlood, 1);
        }
    }
}
