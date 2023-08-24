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
            EnemyController enemyController;
            Enemy1Ai enemyAi;
            enemyAi = other.gameObject.GetComponent<Enemy1Ai>();
            enemyController = other.gameObject.GetComponent<EnemyController>();

            enemyController.currentState = EnemiesState.stand;
            enemyAi.health = enemyAi.health - 2;
            StartCoroutine(Hold(other.gameObject, enemyController));
        }
    }

    IEnumerator Hold(GameObject enemy, EnemyController enemyController)
    {
        yield return new WaitForSeconds(2);
        if (enemy.activeInHierarchy)
        {
            enemyController.currentState = EnemiesState.walking;
        }
        Destroy(gameObject);
    }
}
