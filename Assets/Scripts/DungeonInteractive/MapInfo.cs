using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MapInfo
{
    public List<RoomInfo> RoomInfos;

    public int currentRoomNumber;

    public MissionState missionState;

    public List<CharsTemplate> possibleEnemies { get; set; }
    public Vector2 Size { get; set; }
    public RoomInfo GetCurrentRoomInfo()
    {
        return RoomInfos[currentRoomNumber];
    }

    public int GetNormalizedDifficulty(int roomNumber)
    {
        var maxvalue = possibleEnemies.Max(x => x.EntityChars.Value);
        

        var normalized = (float)roomNumber /
                         (RoomInfos.Count - 1) *
                         maxvalue;

        Debug.Log("(float)roomNumber =" + (float)roomNumber);
        Debug.Log("RoomInfos.Count =" + RoomInfos.Count);
        Debug.Log("maxvalue =" + maxvalue);
        return Mathf.CeilToInt(normalized);
    }

    public void InitEnemyForRoom(RoomInfo roomInfo)
    {
        roomInfo.InitEnemies(GetNormalizedDifficulty(roomInfo.RoomNumber), possibleEnemies);
    }
}
