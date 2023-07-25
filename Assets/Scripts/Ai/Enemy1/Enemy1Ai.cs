using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ai : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject destination1;
    Enemy1State enemyState;
    float distance = 100;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyState = GetComponent<Enemy1State>();
        destination1 = GameObject.Find("Player");
    }

    void Update()
    {
        if (enemyState.isDead || enemyState.isAtacking)
        {
            navMeshAgent.destination = transform.position;
        }
        else
        {
            navMeshAgent.destination = destination1.transform.position;
        }

        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= 3 && !enemyState.isDead)
        {
            enemyState.isAtacking = true;
        }
        else
        {
            enemyState.isAtacking = false;
        }
    }
}
