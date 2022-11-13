using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon 
{
    private DungeonStructure structure;

    public Dungeon(DungeonStructure structure)
    {
        this.structure = structure;
    }

    public List<Room> GetRooms()
    {
        return structure.rooms;
    }

    public List<Corridor> GetCorridors()
    {
        return structure.corridors;
    }
}
