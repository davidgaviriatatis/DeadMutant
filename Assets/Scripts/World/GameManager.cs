using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> hordes = new List<GameObject>();
    public GameObject currentHorde;
    public Horde currentHordeClass;
    public bool gameOver = false, winner = false, pause = false;
    public int gunAmmo = 10, health = 10, enemiesNumber = 0, enemiesSpawned = 0, equippedItem = 1, bearTrapAmount = 3, 
                killedEnemies = 0, hordeNumber = 0;


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
        currentHorde = hordes[0];
        currentHordeClass = currentHorde.GetComponent<Horde>();
        enemiesNumber = currentHordeClass.totalEnemies;
    }

    
    void Update()
    {
        HordeControl();
        Debug.Log("Horda: " + hordeNumber);
        Debug.Log("Matados: " + killedEnemies);
    }

    private void HordeControl()
    {
        if (killedEnemies == currentHordeClass.totalEnemies)
        {
            if (hordeNumber < hordes.Count-1)
            {
                hordeNumber++;
                currentHorde = hordes[hordeNumber];
                currentHordeClass = currentHorde.GetComponent<Horde>();
                enemiesNumber = currentHordeClass.totalEnemies;
                enemiesSpawned = 0;
                killedEnemies = 0;
            }
            else
            {
                Debug.Log("Chefe");
            }
        }
    }
}
