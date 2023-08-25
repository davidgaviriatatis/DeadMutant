using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
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

        if (!activatedEnemy && enemies.Count < 5)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            enemies.Add(newEnemy);
            GameManager.Instance.enemiesSpawned++;
        }

        countDown = timeSpawn;
    }
}
