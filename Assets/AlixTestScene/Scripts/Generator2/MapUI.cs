using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    [SerializeField] GameObject mapContent;

    [SerializeField] GameObject roomUIPrefab;

    [SerializeField] GameObject horCorridorUIPref, verCorridorUIPref;

    [SerializeField] float distanceBetweenRooms;

    private void Update()
    {
        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (wheelScroll != 0)
        {
            mapContent.transform.localScale += new Vector3(wheelScroll, wheelScroll, 0);
        }
    }

    public void CreateDungeonMapUI(Dungeon dungeon)
    {
        ClearMap();

        foreach (var room in dungeon.GetRooms())
        {
            CreateRoomUI(room);
        }

        foreach (var corridor in dungeon.GetCorridors())
        {
            CreateCorridoreUI(corridor);
        }
    }

    private void CreateCorridoreUI(Corridor corridor)
    {
        GameObject corridorUIInstance;

        Vector2 centralPos;

        if (corridor.Orientation == CorridorOrientation.Horizontal)
        {
            float xPos = (corridor.Room1.Coords.x * distanceBetweenRooms + corridor.Room2.Coords.x * distanceBetweenRooms) / 2;

            centralPos = new Vector2(xPos, corridor.Room2.Coords.y * distanceBetweenRooms);

            corridorUIInstance = Instantiate(horCorridorUIPref, mapContent.transform);
        }
        else
        {
            float yPos = (corridor.Room1.Coords.y * distanceBetweenRooms  + corridor.Room2.Coords.y * distanceBetweenRooms) / 2;

            centralPos = new Vector2(corridor.Room2.Coords.x * distanceBetweenRooms, yPos);

            corridorUIInstance = Instantiate(verCorridorUIPref, mapContent.transform);
        }

        corridorUIInstance.transform.localPosition = centralPos;
    }

    private void CreateRoomUI(Room room)
    {
        GameObject roomInstance = Instantiate(roomUIPrefab, mapContent.transform);

        var possition = new Vector3(room.Coords.x * distanceBetweenRooms, room.Coords.y * distanceBetweenRooms, 0);

        roomInstance.transform.localPosition = possition;
    }

    private void ClearMap()
    {
        foreach (Transform child in mapContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
