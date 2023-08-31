using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimation : MonoBehaviour
{
    public Animator animator;

    public void enemyRun(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }

    public void enemyDead(bool isDead)
    {
        animator.SetBool("isDead", isDead);
    }

    public void enemyAttack(bool isAttacking)
    {
        animator.SetBool("isAttacking", isAttacking);
    }

    public void enemyShoot(bool isShooting)
    {
        animator.SetBool("isShooting", isShooting);
    }
}
