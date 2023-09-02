using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject bearTrap;

    PlayerSounds playerSounds;

    void Start()
    {
        playerSounds = GetComponent<PlayerSounds>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.gameOver)
        {
            switch (GameManager.Instance.equippedItem)
            {
                case 1:
                    InstanBearTrap();
                    break;

                case 2:
                    HealthPlayer();
                    break;

                default:
                    break;
            }
        }
    }

    //--------------------Métodos personalizados-----------------------

    private void HealthPlayer()
    {
        if (GameManager.Instance.healthKitAmount > 0)
        {
            playerSounds.UseHealthkit();
            GameManager.Instance.health += 4;

            if (GameManager.Instance.health > GameManager.Instance.maxHealth)
            {
                GameManager.Instance.health = GameManager.Instance.maxHealth;
            }

            GameManager.Instance.healthKitAmount--;

            Debug.Log("vida: " + GameManager.Instance.health);
        }
    }

    private void InstanBearTrap()
    {
        if (GameManager.Instance.bearTrapAmount > 0)
        {
            playerSounds.UseBearTrap();

            Vector3 positionTrap = transform.position;
            positionTrap.y = 0.3f;

            Instantiate(bearTrap, positionTrap, transform.rotation);

            GameManager.Instance.bearTrapAmount--;
        }
    }
}
