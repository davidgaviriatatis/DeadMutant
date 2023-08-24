using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyController>().currentState != EnemiesState.dying)
            {
                GameObject newBlood = Instantiate(bloodEffect, transform.position, transform.rotation);
                collision.gameObject.GetComponent<Enemy1Ai>().health--;
                Destroy(newBlood, 1);
            }

            Destroy(gameObject);
        }
    }
}
