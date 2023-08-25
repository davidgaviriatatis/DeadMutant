using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ai : MonoBehaviour, IEnemyAction
{
    public int attackDistance = 2, health = 3;
    public float rayDistance = 2f;
    public Transform attackPoint;
    public LayerMask mask;

    GameObject destination1;
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

    //----------------Métodos personalizados-------------

    public void canWalk() => enemyState.currentState = EnemiesState.walking;

    public void attackImpact()
    {
        //Debug.DrawRay(attackPoint.position, attackPoint.forward * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, rayDistance, mask))
        {
            GameManager.Instance.health--;
            Debug.Log(GameManager.Instance.health);
        }
    }

    IEnumerator deadRestart()
    {
        yield return new WaitForSeconds(3);
        health = 3;
        navMeshAgent.destination = destination1.transform.position;
        animator.enemyDead(false);
        gameObject.SetActive(false);
    }

    //---------------Métodos implementados interface---------------

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
        animator.enemyAttack(false);
        animator.enemyDead(true);
        navMeshAgent.destination = transform.position;
        StartCoroutine(deadRestart());
    }

    public void caught()
    {
        navMeshAgent.destination = transform.position;
    }
}
