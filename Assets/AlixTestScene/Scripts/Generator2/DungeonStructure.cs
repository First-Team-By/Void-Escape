using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonStructure 
{
    public List<Room> rooms;

    public Dictionary<Room, List<Room>> roomToConnectedRooms;

    public List<Corridor> corridors;
}
