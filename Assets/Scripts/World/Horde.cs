using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> amount = new List<int>();
    public List<int> spawnedEnemies = new List<int>();
    public int totalEnemies = 0;

    void Start()
    {
        foreach (var number in amount)
        {
            totalEnemies += number;
            spawnedEnemies.Add(0);
        }
    }
}
