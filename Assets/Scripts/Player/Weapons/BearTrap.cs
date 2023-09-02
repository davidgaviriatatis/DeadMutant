using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioTrap;

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
            audioTrap.Play();
            EnemyController enemyController;
            Enemy1Ai enemyAi;
            enemyAi = other.gameObject.GetComponent<Enemy1Ai>();
            enemyController = other.gameObject.GetComponent<EnemyController>();

            enemyController.currentState = EnemiesState.stand;
            enemyController.health = enemyController.health - 2;
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
