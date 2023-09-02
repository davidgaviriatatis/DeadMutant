using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss1Ai : MonoBehaviour, IEnemyAction
{
    public int attackDistance = 2;
    public float shotForce = 700f, rayDistance = 3f;
    public Transform attackPoint;
    public LayerMask mask;

    GameObject destination1;
    NavMeshAgent navMeshAgent;
    EnemyController enemyState;
    EnemiesAnimation animator;
    float distance = 4;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyState = GetComponent<EnemyController>();
        animator = GetComponent<EnemiesAnimation>();
        destination1 = GameManager.Instance.player;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= attackDistance && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.attacking)
        {
            enemyState.currentState = EnemiesState.attacking;
        }
        else if (enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.attacking)
        {
            canWalk();
        }
    }

    //----------------Métodos personalizados-------------

    public void canWalk() => enemyState.currentState = EnemiesState.walking;

    public void meleAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, rayDistance, mask))
        {
            GameManager.Instance.health -= 2;
            hit.transform.GetComponent<PlayerSounds>().DamageSound();
        }
    }

    IEnumerator deadRestart()
    {
        yield return new WaitForSeconds(3);
        enemyState.health = 5;
        navMeshAgent.destination = destination1.transform.position;
        animator.enemyDead(false);
        GameManager.Instance.killedEnemies++;
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
        transform.LookAt(GameManager.Instance.player.transform);
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
