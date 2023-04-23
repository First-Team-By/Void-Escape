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
    public Loot CreateLoot(float currentMapProgress, List<LootItemInfo> possibleLoot)
    {
        var result = new Loot();

        foreach (var item in possibleLoot) 
        {
            float amount = 1;
            var value = Random.Range(0, 1f);
            if (item.Type == typeof(Equipment))
            {
                value *= currentMapProgress;
            }
            else
            {
                amount = currentMapProgress * item.Rarity * 5;
            }

            if (value <= item.Rarity)
            {
                var battery = Activator.CreateInstance(item.Type);
                result.Items.Add((LootItem)battery);
            }
        }
        return result;
    }
    public List<EnemyInfo> CreateEnemies(int difficulty, List<CharsTemplate> possibleEnemies)
    {
        var enemyValues = GetEnemyValues(difficulty);

        List<EnemyInfo> enemiesInfos = new List<EnemyInfo>(enemyValues.Length);
        for (int i = 0; i < enemyValues.Length; i++)
        {
            try
            {
                var _class = possibleEnemies.First(x => x.EntityChars.Value == enemyValues[i]).GetEntityClass();
                var enemyInfo = (EnemyInfo)Activator.CreateInstance(_class);
                enemiesInfos.Add(enemyInfo);
            }
            catch
            {
                Debug.LogError("Несуществующий уровень сложности: " + enemyValues[i]);
            }
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
