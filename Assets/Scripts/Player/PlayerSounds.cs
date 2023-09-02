using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource shotPistol, acidBallImpact, meleAttack, dead, useBearT, useHealtK, damage;

    public void ShotPistolSound()
    {
        shotPistol.Play();
    }

    public void AcidBallImpactSound()
    {
        acidBallImpact.Play();
    }

    public void MeleAttackSound()
    {
        meleAttack.Play();
    }

    public void DeadSound()
    {
        dead.Play();
    }

    public void UseBearTrap()
    {
        useBearT.Play();
    }

    public void UseHealthkit()
    {
        useHealtK.Play();
    }

    public void DamageSound()
    {
        damage.Play();
    }
}
