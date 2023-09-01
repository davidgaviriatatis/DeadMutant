using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Slider sliderHealth;
    public TMP_Text ammoText, itemAmmoText, hordeTimeText;
    public Image bearTrapImage, redCrossImage;
    public List<GameObject> hordes = new List<GameObject>();
    public GameObject currentHorde, spawnBossPoint, bossPrefab, player;
    public Horde currentHordeClass;
    public bool gameOver = false, winner = false, pause = false;
    public float timeHordes = 30;
    public int gunAmmo = 10, health = 10, enemiesNumber = 0, enemiesSpawned = 0, equippedItem = 1, bearTrapAmount = 3, 
                killedEnemies = 0, hordeNumber = 0, healthKitAmount = 2, maxItem = 2, maxHealth = 10;

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
        health = maxHealth;
        hordeTimeText.enabled = false;
    }

    
    void Update()
    {
        assignUIValues();

        if (Input.GetKeyDown(KeyCode.R))
        {
            changeEquipment();
        }

        HordeControl();
        Debug.Log("Horda: " + hordeNumber);
    }

    //--------------------Métodos personalizados-----------------------

    private void assignUIValues()
    {
        sliderHealth.value = health;
        ammoText.text = gunAmmo.ToString();

        if (hordeTimeText.isActiveAndEnabled)
        {
            hordeTimeText.text = countDownHorde.ToString("F0");
        }

        switch (equippedItem)
        {
            case 1:
                bearTrapImage.enabled = true;
                redCrossImage.enabled = false;
                itemAmmoText.text = bearTrapAmount.ToString();
                break;

            case 2:
                bearTrapImage.enabled = false;
                redCrossImage.enabled = true;
                itemAmmoText.text = healthKitAmount.ToString();
                break;
        }
    }

    private void changeEquipment()
    {
        if (equippedItem < maxItem)
        {
            equippedItem++;
        }
        else
        {
            equippedItem = 1;
        }

        Debug.Log(equippedItem);
    }

    private void HordeControl()
    {
        if (killedEnemies >= currentHordeClass.totalEnemies)
        {
            if (!hordeTimeText.isActiveAndEnabled)
            {
                hordeTimeText.enabled = true;
            }

            countDownHorde -= Time.deltaTime;

            if (hordeNumber < hordes.Count-1 && countDownHorde <= 0)
            {
                hordeTimeText.enabled = false;
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
                hordeTimeText.enabled = false;
                countDownHorde = timeHordes;
                killedEnemies = 0;

                Instantiate(bossPrefab, spawnBossPoint.transform.position, spawnBossPoint.transform.rotation);
            }
        }
    }
}
