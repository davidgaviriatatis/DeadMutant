using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemiesState currentState = EnemiesState.walking;

    IEnemyAction enemyAction;

    void Start()
    {
        enemyAction = GetComponent<IEnemyAction>();
    }

    void Update()
    {
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
