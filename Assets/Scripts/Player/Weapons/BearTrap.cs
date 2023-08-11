using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public GameObject player;

    bool enemieEnter = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemieEnter)
        {
            enemieEnter = true;
            Enemy1State enemyState;
            Enemy1Ai enemyAi;
            enemyState = other.gameObject.GetComponent<Enemy1State>();
            enemyAi = other.gameObject.GetComponent<Enemy1Ai>();

            enemyState.health = enemyState.health - 2;
            enemyAi.destination1 = other.gameObject;
            StartCoroutine(Hold(other.gameObject, enemyAi));
        }
    }

    IEnumerator Hold(GameObject enemy, Enemy1Ai enemyAi)
    {
        yield return new WaitForSeconds(2);
        if (enemy.activeInHierarchy)
        {
            enemyAi.destination1 = player;
        }
        Destroy(gameObject);
    }
}
