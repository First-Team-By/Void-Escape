using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator2 : MonoBehaviour
{
    [SerializeField] DungeonSettings settings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dungeon dungeon = CreateDungeon(settings);

            FindObjectOfType<MapUI>().CreateDungeonMapUI(dungeon);
        }
    }

    public Dungeon CreateDungeon(DungeonSettings settings)
    {
        DungeonStructure structure = new DungeonStructure();

        structure.rooms = CreateRooms();

        structure.roomToConnectedRooms = ConnectRooms(structure.rooms);

        structure.corridors = CreateCorridors(structure.roomToConnectedRooms);

        return new Dungeon(structure);
    }

    private List<Corridor> CreateCorridors(Dictionary<Room, List<Room>> roomToConnectedRooms)
    {
        List<Corridor> corridors = new List<Corridor>();

        List<Room> connectedRooms = new List<Room>();

        foreach (var room in roomToConnectedRooms.Keys)
        {
            foreach (var connectedRoom in roomToConnectedRooms[room])
            {
                if (connectedRooms.Contains(connectedRoom))
                {
                    continue;
                }

                var newCorridor = new Corridor(room, connectedRoom);

                corridors.Add(newCorridor);
            }

            connectedRooms.Add(room);
        }

        return corridors;
    }

    private Dictionary<Room, List<Room>> ConnectRooms(List<Room> rooms)
    {
        Dictionary<Room, List<Room>> roomToConnectedRooms = new Dictionary<Room, List<Room>>();


        for (int i = 0; i < rooms.Count; i++)
        {
            List<Room> connectedRooms = new List<Room>();

            for (int j = 0; j < rooms.Count; j++)
            {
                int xDistance = Mathf.Abs(rooms[i].Coords.x - rooms[j].Coords.x);

                int yDistance = Mathf.Abs(rooms[i].Coords.y - rooms[j].Coords.y);

                if (xDistance + yDistance == 1)
                {
                    connectedRooms.Add(rooms[j]);
                }
            }

            roomToConnectedRooms[rooms[i]] = connectedRooms;
        }

        return roomToConnectedRooms;
    }

    private List<Room> CreateRooms()
    {
        List<Room> rooms = new List<Room>();

        Vector2Int nextCoords = Vector2Int.zero;

        int roomsToCreate = Random.Range(settings._minNumberOfRooms, settings._maxNumberOfRooms);

        List<Vector2Int> usedCoords = new List<Vector2Int>();

        while (roomsToCreate > 0)
        {
            if (rooms.Count > 0)
            {
                nextCoords = RandomGeneratePosRoom(nextCoords);
            }

            if (usedCoords.Contains(nextCoords))
            {
                continue;
            }

            Room room = new Room(rooms.Count + 1, nextCoords);

            rooms.Add(room);

            usedCoords.Add(nextCoords);

            roomsToCreate--;
        }

        return rooms;
    }

    private Vector2Int RandomGeneratePosRoom(Vector2Int nextCoords)
    {
        float randomNumber = Random.Range(0, 1f);

        if (randomNumber <= 0.25f)
        {
            return new Vector2Int(nextCoords.x - 1, nextCoords.y);
        }

        else if (randomNumber <= 0.5f)
        {
            return new Vector2Int(nextCoords.x + 1, nextCoords.y);
        }

        else if (randomNumber <= 0.75f)
        {
            return new Vector2Int(nextCoords.x, nextCoords.y - 1);
        }

        else
        {
            return new Vector2Int(nextCoords.x, nextCoords.y + 1);
        }
    }
}
