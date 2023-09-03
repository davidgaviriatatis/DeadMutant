using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBox : MonoBehaviour
{
    public AudioClip soundBox;

    AudioSource pickBoxSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickBoxSound = other.gameObject.GetComponent<AudioSource>();
            pickBoxSound.PlayOneShot(soundBox);
            GameManager.Instance.gunAmmo += 10;
            gameObject.SetActive(false);
        }
    }
}
