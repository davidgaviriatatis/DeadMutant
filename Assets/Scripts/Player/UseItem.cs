using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject bearTrap;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (GameManager.Instance.equippedItem)
            {
                case 1:
                    InstanBearTrap();
                    break;

                default:
                    break;
            }
        }
    }

    private void InstanBearTrap()
    {
        if (GameManager.Instance.bearTrapAmount > 0)
        {

            Vector3 positionTrap = transform.position;
            positionTrap.y = 0.3f;

            Instantiate(bearTrap, positionTrap, transform.rotation);

            GameManager.Instance.bearTrapAmount--;
        }
    }
}
