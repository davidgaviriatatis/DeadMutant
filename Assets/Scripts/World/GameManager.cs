using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> hordes = new List<GameObject>();
    public GameObject currentHorde, spawnBossPoint, bossPrefab, player;
    public Horde currentHordeClass;
    public bool gameOver = false, winner = false, pause = false;
    public float timeHordes = 30;
    public int gunAmmo = 10, health = 10, enemiesNumber = 0, enemiesSpawned = 0, equippedItem = 1, bearTrapAmount = 3, 
                killedEnemies = 0, hordeNumber = 0;

    float countDownHorde;


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
        countDownHorde = timeHordes;
        currentHorde = hordes[0];
        currentHordeClass = currentHorde.GetComponent<Horde>();
        enemiesNumber = currentHordeClass.totalEnemies;
    }

    
    void Update()
    {
        HordeControl();
        Debug.Log("Horda: " + hordeNumber);
    }

    private void HordeControl()
    {
        if (killedEnemies >= currentHordeClass.totalEnemies)
        {
            countDownHorde -= Time.deltaTime;

            if (hordeNumber < hordes.Count-1 && countDownHorde <= 0)
            {
                hordeNumber++;
                currentHorde = hordes[hordeNumber];
                currentHordeClass = currentHorde.GetComponent<Horde>();
                enemiesNumber = currentHordeClass.totalEnemies;
                enemiesSpawned = 0;
                killedEnemies = 0;
                countDownHorde = timeHordes;
            }
            else if(countDownHorde <= 0)
            {
                Debug.Log("Chefe");
                countDownHorde = timeHordes;
                killedEnemies = 0;

                Instantiate(bossPrefab, spawnBossPoint.transform.position, spawnBossPoint.transform.rotation);
            }
        }
    }
}
