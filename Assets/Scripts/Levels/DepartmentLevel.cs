using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DepartmentLevel 
{
    public List<EnemyInfo> CreateEnemies(int difficulty, List<EnemyInfo> possibleEnemies)
    {
        var enemyPrefabs = possibleEnemies.Select(x => x.EnemyPrefab);

        var enemyValues = GetEnemyValues(difficulty);

        List<EnemyInfo> enemiesInfos = new List<EnemyInfo>(enemyValues.Length);
        for (int i = 0; i < enemyValues.Length; i++)
        {
            //var enemyGO = GameObject.Instantiate(enemyPrefabs.FirstOrDefault(x => x.gameObject.GetComponent<Enemy>().EntityChars.Value == enemyValues[i]));
            //enemies.Add(enemyGO.GetComponent<Enemy>());
            var enemyInfo = new EnemyInfo();
            try
            {
                enemyInfo.EnemyPrefab =
                enemyPrefabs.First(x => x.GetComponent<Enemy>().EntityChars.Value == enemyValues[i]);
            }
            catch
            {
                Debug.LogError("Несуществующий уровень сложности: " + enemyValues[i]);
            }
            
            enemiesInfos.Add(enemyInfo);
        }
        return enemiesInfos;
    }

    private int[] GetEnemyValues(int difficulty)
    {
        int enemyCount = Math.Min(Random.Range(1, 6), difficulty);

        int[] result = new int[enemyCount];
        int average = difficulty / enemyCount;
        int remainder = difficulty % enemyCount;

        //Debug.Log("average - " + average);
        //Debug.Log("enemyCount - " + enemyCount);

        for (int i = 0; i < enemyCount - remainder; i++)
        {
            result[i] = average;
            //Debug.Log("Уровень сложности - " + result[i]);
        }

        for (int i = enemyCount - remainder; i < enemyCount; i++)
        {
            result[i] = average + 1;
            //Debug.Log("Уровень сложности - " + result[i]);
        }

        return result;
    }
}
