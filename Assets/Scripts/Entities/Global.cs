using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Global
{
    public static CharacterGroup currentGroup;

    public static List<GameObject> enemyPrefabs;

    private static GameObject container;

    static Global()
    {
        container = Resources.Load<GameObject>("EnemyPrefabsContainer");
        enemyPrefabs = container.GetComponent<EnemyPrefabs>().EnemyList;
    }
}
