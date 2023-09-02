using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ai : MonoBehaviour, IEnemyAction
{
    public int attackDistance = 2;
    public float rayDistance = 2f;
    public Transform attackPoint;
    public LayerMask mask;

    GameObject destination1;
    NavMeshAgent navMeshAgent;
    EnemyController enemyState;
    EnemiesAnimation animator;
    EnemySounds enemySound;
    float distance = 100;
    bool activeDead = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyState = GetComponent<EnemyController>();
        animator = GetComponent<EnemiesAnimation>();
        enemySound = GetComponent<EnemySounds>();
        destination1 = GameObject.Find("Player");
    }

    void Update()
    {
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
            hit.transform.GetComponent<PlayerSounds>().DamageSound();
        }
    }

    IEnumerator deadRestart()
    {
        yield return new WaitForSeconds(4);
        enemyState.health = 3;
        activeDead = false;
        navMeshAgent.destination = destination1.transform.position;
        animator.enemyDead(false);
        enemyState.currentState = EnemiesState.walking;
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
        //transform.LookAt(GameManager.Instance.player.transform.position);
        navMeshAgent.destination = transform.position;
        animator.enemyAttack(true);
    }

    public void died()
    {
        if (!activeDead)
        {
            enemySound.DeadSound();
            activeDead = true;
        }

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
