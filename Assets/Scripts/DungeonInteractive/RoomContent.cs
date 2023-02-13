using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContent
{
    private List<EnemyInfo> _enemyInfos;
    public List<EnemyInfo> EnemyInfos => _enemyInfos;

    public RoomContent(List<EnemyInfo> enemyInfos)
    {
        _enemyInfos = enemyInfos;
        SaveToGlobal();
    }

    private void SaveToGlobal()
    {
        Global.currentRoomContent = this;
    }
}
