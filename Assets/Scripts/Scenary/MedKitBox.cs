using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitBox : MonoBehaviour
{
    public AudioClip soundBox;

    AudioSource pickBoxSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickBoxSound = other.gameObject.GetComponent<AudioSource>();
            pickBoxSound.PlayOneShot(soundBox);
            GameManager.Instance.healthKitAmount += 1;
            gameObject.SetActive(false);
        }
    }
}
