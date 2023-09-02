using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioSource neutral, dead, attack1, attack2, impact;

    public void NeutralSound()
    {
        neutral.Play();
    }

    public void DeadSound()
    {
        dead.Play();
    }

    public void ImpactSound()
    {
        impact.Play();
    }

    public void Attack1Sound()
    {
        attack1.Play();
    }

    public void Attack2Sound()
    {
        attack2.Play();
    }
}
