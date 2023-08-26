using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeSpawn = 5f;

    List<GameObject> enemies = new List<GameObject>();
    Horde activeHorde;
    float countDown;
    int enemiesNumber, positionSpawn = 0;

    void Start()
    {
        countDown = timeSpawn;
        enemiesNumber = GameManager.Instance.enemiesNumber;
    }

    void Update()
    {
        if (GameManager.Instance.enemiesSpawned == 0)
        {
            activeHorde = GameManager.Instance.currentHordeClass;
            Debug.Log("ANTES: " + activeHorde.spawnedEnemies[positionSpawn] + GameManager.Instance.enemiesSpawned);

            for (int i = 0; i < activeHorde.enemies.Count; i++)
            {
                if (enemyPrefab.transform.name == activeHorde.enemies[i].transform.name)
                {
                    enemiesNumber = activeHorde.amount[i];
                    positionSpawn = i;
                    Debug.Log("DESPUES: " + activeHorde.spawnedEnemies[positionSpawn]);
                    break;
                }
            }
        }

        countDown -= Time.deltaTime;

        if (countDown <= 0 && activeHorde.spawnedEnemies[positionSpawn] < enemiesNumber)
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
            activeHorde.spawnedEnemies[positionSpawn]++;
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
                    activeHorde.spawnedEnemies[positionSpawn]++;
                    break;
                }
            }
        }

        if (!activatedEnemy && enemies.Count < 15)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            enemies.Add(newEnemy);
            GameManager.Instance.enemiesSpawned++;
            activeHorde.spawnedEnemies[positionSpawn]++;
        }

        countDown = timeSpawn;
    }
}
