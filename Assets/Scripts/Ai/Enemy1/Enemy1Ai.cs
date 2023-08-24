using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ai : MonoBehaviour, IEnemyAction
{
    public GameObject destination1;
    public int attackDistance = 3, health = 3;

    NavMeshAgent navMeshAgent;
    EnemyController enemyState;
    EnemiesAnimation animator;
    float distance = 100;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyState = GetComponent<EnemyController>();
        animator = GetComponent<EnemiesAnimation>();
        destination1 = GameObject.Find("Player");
    }

    void Update()
    {
        if (health <= 0)
        {
            enemyState.currentState = EnemiesState.dying;
        }

        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= attackDistance && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.attacking)
        {
            enemyState.currentState = EnemiesState.attacking;
        }
        else if(enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.attacking)
        {
            canWalk();
        }
    }

    public void canWalk()
    {
        enemyState.currentState = EnemiesState.walking;
    }

    public void walk()
    {
        navMeshAgent.destination = destination1.transform.position;
        animator.enemyAttack(false);
    }

    public void attack()
    {
        navMeshAgent.destination = transform.position;
        animator.enemyAttack(true);
    }

    public void died()
    {
        gameObject.SetActive(false);
    }

    public void caught()
    {
        navMeshAgent.destination = transform.position;
    }
}
