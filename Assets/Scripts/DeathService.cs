using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathService : MonoBehaviour
{
    private List<(Enemy enemyExample, Func<bool> deathCondition)> _registeredEnemies 
        = new List<(Enemy, Func<bool>)>();

    public void Register(Enemy enemy, Func<bool> conditionToDie)
    {
        _registeredEnemies.Add((enemy, conditionToDie));
    }

    private void Update()
    {
        Debug.Log($"Зарегестрировано врагов: {_registeredEnemies.Count}");
        
        for(int i = _registeredEnemies.Count - 1; i >= 0; i--)
        {
            if (_registeredEnemies[i].deathCondition.Invoke() == true)
            {
                Destroy(_registeredEnemies[i].enemyExample.gameObject);
                _registeredEnemies.RemoveAt(i);
            }
        }
    }

    public float CountEnemys()
    {
        return _registeredEnemies.Count;
    }
}
