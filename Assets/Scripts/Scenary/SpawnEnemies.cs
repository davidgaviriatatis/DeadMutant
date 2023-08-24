using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemySpitPrefab;
    public float timeSpawn = 5f;

    List<GameObject> enemies = new List<GameObject>();
    float countDown;
    int enemiesNumber;

    void Start()
    {
        countDown = timeSpawn;
        enemiesNumber = GameManager.Instance.enemiesNumber;
    }

    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0 && GameManager.Instance.enemiesSpawned < enemiesNumber)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        bool activatedEnemy = false;

        if (enemies.Count <= 0)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            enemies.Add(newEnemy);
            activatedEnemy = true;
            GameManager.Instance.enemiesSpawned++;
        }
        else
        {
            foreach (var enemyInList in enemies)
            {
                if (!enemyInList.activeInHierarchy)
                {
                    enemyInList.SetActive(true);
                    enemyInList.transform.position = transform.position;
                    activatedEnemy = true;
                    GameManager.Instance.enemiesSpawned++;
                    break;
                }
            }
        }

        if (!activatedEnemy && GameManager.Instance.enemiesSpawned < 25)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            enemies.Add(newEnemy);
            GameManager.Instance.enemiesSpawned++;

            if (GameManager.Instance.enemiesSpawned <=5 )
            {
                //Debug.Log("Primera horda");
            }

            if (GameManager.Instance.enemiesSpawned == 6)
            {
                //Debug.Log("Segunda horda");
            }   

            if (GameManager.Instance.enemiesSpawned == 15)
            {
                //Debug.Log("Tercera horda");
            }

            //Debug.Log(GameManager.Instance.enemiesSpawned);
        }

        if (!activatedEnemy && GameManager.Instance.enemiesSpawned >= 25 && GameManager.Instance.enemiesSpawned < 28) 
        {
            GameObject newEnemy = Instantiate(enemySpitPrefab, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            enemies.Add(newEnemy);
            GameManager.Instance.enemiesSpawned++;
            //Debug.Log(GameManager.Instance.enemiesSpawned);
        }

        if(!activatedEnemy && GameManager.Instance.enemiesSpawned == 28)
        {
            /*Debug.Log("Boss");
            Debug.Log(GameManager.Instance.enemiesSpawned);*/
        }

        countDown = timeSpawn;
    }
}
