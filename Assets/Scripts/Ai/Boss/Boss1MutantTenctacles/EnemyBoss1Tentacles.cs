using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1Tentacles : MonoBehaviour, IEnemyAction
{
    public int attackDistance = 8, attackDistanceMax = 20;
    public float shotForce = 700f;
    public Transform attackPoint1, attackPoint2;
    public LayerMask playerMask;
    public GameObject acidBall;

    GameObject destination1;
    EnemyController enemyState;
    EnemiesAnimation animator;
    float distance = 4, sphereRadius = 4f;
    int attackType = 1;

    void Start()
    {
        enemyState = GetComponent<EnemyController>();
        animator = GetComponent<EnemiesAnimation>();
        destination1 = GameManager.Instance.player;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= attackDistance && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.attacking)
        {
            canAttack(1);
        }
        else if (distance > attackDistance && distance <= attackDistanceMax && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.attacking)
        {
            canAttack(2);
        }
        else if (enemyState.currentState != EnemiesState.stand && enemyState.currentState != EnemiesState.dying && enemyState.currentState != EnemiesState.attacking)
        {
            canWalk();
        }
    }

    //----------------Métodos personalizados-------------

    public void canWalk() => enemyState.currentState = EnemiesState.walking;

    public void canAttack(int type)
    {
        attackType = type;
        enemyState.currentState = EnemiesState.attacking;
    }

    public void meleAttack1(int attackNumber)
    {
        if (attackNumber == 1)
        {
            checkImpactPlayer(attackPoint1);
        }
        else if(attackNumber == 2)
        {
            checkImpactPlayer(attackPoint2);
        }
        else if (attackNumber == 3)
        {
            checkImpactPlayer(attackPoint1);
            checkImpactPlayer(attackPoint2);
        }
    }

    public void acidBallAttack()
    {
        Instantiate(acidBall, attackPoint1.position, attackPoint1.rotation);
        Instantiate(acidBall, attackPoint2.position, attackPoint2.rotation);
    }

    private void checkImpactPlayer(Transform pointImpact)
    {
        if (Physics.CheckSphere(pointImpact.position, sphereRadius, playerMask))
        {
            GameManager.Instance.health -= 3;
            Debug.Log(GameManager.Instance.health);
        }
    }

    //---------------Métodos implementados interface---------------

    public void walk()
    {
        animator.enemyAttack(false);
        animator.enemyShoot(false);
    }

    public void attack()
    {
        if (attackType == 1)
        {
            animator.enemyAttack(true);
            animator.enemyShoot(false);
        }
        else if (attackType == 2)
        {
            animator.enemyAttack(false);
            animator.enemyShoot(true);
        }
    }

    public void died()
    {
        animator.enemyAttack(false);
        animator.enemyShoot(false);
        animator.enemyDead(true);
    }

    public void caught()
    {
    }
}
