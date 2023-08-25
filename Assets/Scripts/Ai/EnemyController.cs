using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemiesState currentState = EnemiesState.walking;
    public int health;

    IEnemyAction enemyAction;

    void Start()
    {
        enemyAction = GetComponent<IEnemyAction>();
    }

    void Update()
    {
        if (health <= 0)
        {
            currentState = EnemiesState.dying;
        }

        switch (currentState)
        {
            case EnemiesState.walking:
                enemyAction.walk();
                break;

            case EnemiesState.attacking:
                enemyAction.attack();
                break;

            case EnemiesState.dying:
                enemyAction.died();
                break;

            case EnemiesState.stand:
                enemyAction.caught();
                break;
        }
    }
}
