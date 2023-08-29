using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpitterAi : MonoBehaviour, IEnemyAction
{
    public int attackDistance = 6;
    public float shotForce = 700f;
    public Transform attackPoint;
    public GameObject acidBall;

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

    public void acidBallAttack()
    {
        transform.LookAt(GameManager.Instance.player.transform);

        GameObject newAcidBall;

        newAcidBall = Instantiate(acidBall, attackPoint.position, attackPoint.rotation);

        //newAcidBall.GetComponent<Rigidbody>().AddForce(attackPoint.forward * shotForce);

        //Destroy(newAcidBall, 3);
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

    IEnumerator restartWalk()
    {
        yield return new WaitForSeconds(2);
        canWalk();
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
        StartCoroutine(restartWalk());
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
