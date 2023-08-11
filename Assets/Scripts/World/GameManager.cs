using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool gameOver = false, winner = false, pause = false;
    public int gunAmmo = 10, health = 10, enemiesNumber = 30, enemiesSpawned = 0, equippedItem = 1, bearTrapAmount = 3;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
