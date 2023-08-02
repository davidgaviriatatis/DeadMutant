using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1State : MonoBehaviour
{
    public bool isDead = false, isAtacking = false;
    public int health = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
