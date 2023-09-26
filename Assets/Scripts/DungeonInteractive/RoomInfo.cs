using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class RoomInfo
{
    private List<EnemyInfo> _enemyInfos;
    public Loot Loot { get; private set; }


    public bool[] status = new bool[4];

    public int x, y;

    public List<int> neighbours = new List<int>();

    public int GlobalRoomNumber { get; set; }

    public int RoomNumber { get; set; }
    public List<EnemyInfo> EnemyInfos => _enemyInfos;
    

    public bool Inhabitable
    {
        get
        {
            return _enemyInfos != null && _enemyInfos.Count > 0;
        }
    }

    public RoomInfo(List<EnemyInfo> enemyInfos, RoomBehaviour room)
    {
        _enemyInfos = enemyInfos;
    }

    public RoomInfo()
    {
        
    }

    public void InitEnemies(int difficulty, List<CharsTemplate> possibleEnemyInfos)
    {
        _enemyInfos = new DepartmentLevel().CreateEnemies(difficulty, possibleEnemyInfos);
    }

    public void CreateLoot(float currentMapProgress, List<LootItemInfo> possibleLoot)
    {
        Loot = new DepartmentLevel().CreateLoot(currentMapProgress, possibleLoot);
    }
}
