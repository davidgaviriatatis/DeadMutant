using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAction
{
    public void walk();
    public void attack();
    public void died();
    public void caught();
}
