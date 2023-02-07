using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DepartmentLevel 
{
    public List<Enemy> CreateEnemies(int difficulty, int enemyCount)
    {
        var enemyPrefabs = Global.enemyPrefabs;

        var enemyValues = GetEnemyValues(difficulty, enemyCount);

        List<Enemy> enemies = new List<Enemy>(enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            var enemyGO = GameObject.Instantiate(enemyPrefabs.FirstOrDefault(x => x.gameObject.GetComponent<Enemy>().EntityChars.Value == enemyValues[i]));
            enemies.Add(enemyGO.GetComponent<Enemy>());
        }
        return enemies;
    }

    private int[] GetEnemyValues(int difficulty, int enemyCount)
    {
        int currentDifficulty = difficulty;
        int enemiesToAdd = enemyCount;
        int[] values = new int[enemyCount];

        for (int i = 0; i < enemyCount; i++)
        {
            if (enemiesToAdd == 1)
            {
                values[i] = currentDifficulty;
                break;
            }
            int randomValue = Random.Range(1, currentDifficulty - (enemiesToAdd - 1));
            values[i] = randomValue;
            currentDifficulty -= randomValue;
            enemiesToAdd--;
        }

        Array.Sort(values);
        Array.Reverse(values);
        return values;
    }
}
