using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator animator;
    public float health = 10;
    public bool isRunning = false, isShooting = false, isAttackingMele = false, isDying = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isRunning)
        {
            MovePlayer(true);
        }
        else
        {
            MovePlayer(false);
        }

        if (isShooting)
        {
            ShotPlayer(true);
        }
        else
        {
            ShotPlayer(false);
        }

        if (isAttackingMele)
        {
            MelePlayer(true);
        }
        else
        {
            MelePlayer(false);
        }

        if (isDying)
        {
            DeadPlayer(true);
            MovePlayer(false);
            ShotPlayer(false);
            MelePlayer(false);
        }
    }

    private void MovePlayer(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }

    private void ShotPlayer(bool isShooting)
    {
        animator.SetBool("IsShooting", isShooting);
    }

    private void MelePlayer(bool isAttackingMele)
    {
        animator.SetBool("isAttackingMele", isAttackingMele);
    }

    private void DeadPlayer(bool isDead)
    {
        animator.SetBool("isDead", isDead);
    }
}
