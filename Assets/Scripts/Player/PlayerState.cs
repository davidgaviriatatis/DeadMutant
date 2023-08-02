using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator animator;
    public float health = 10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MovePlayer(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }

    public void ShotPlayer(bool isShooting)
    {
        animator.SetBool("IsShooting", isShooting);
    }
}
