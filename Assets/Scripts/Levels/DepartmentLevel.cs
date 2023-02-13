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
    public List<EnemyInfo> CreateEnemies(int difficulty)
    {
        var enemyPrefabs = Global.EnemyPrefabs.EnemyPrefabsList;

        var enemyValues = GetEnemyValues(difficulty);

        List<EnemyInfo> enemiesInfos = new List<EnemyInfo>(enemyValues.Length);
        for (int i = 0; i < enemyValues.Length; i++)
        {
            //var enemyGO = GameObject.Instantiate(enemyPrefabs.FirstOrDefault(x => x.gameObject.GetComponent<Enemy>().EntityChars.Value == enemyValues[i]));
            //enemies.Add(enemyGO.GetComponent<Enemy>());
            var enemyInfo = new EnemyInfo();
            enemyInfo.EnemyPrefab =
                enemyPrefabs.FirstOrDefault(x => x.GetComponent<Enemy>().EntityChars.Value == enemyValues[i]);
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

        for (int i = 0; i < enemyCount - remainder; i++)
        {
            result[i] = average;
        }

        for (int i = enemyCount - remainder; i < enemyCount; i++)
        {
            result[i] = average + 1;
        }

        return result;
    }
}
