using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private DungeonGenerator dungeonGenerator;

    private List<RoomBehaviour> rooms;

    [SerializeField] private GameObject _groupMarker;

    void Start()
    {
        rooms = dungeonGenerator.MazeGenerator();

        Global.currentRoomNumber = 0;

        SetGroupMarker(rooms[0]);
    }

    void Update()
    {
        
    }

    public void SetGroupMarker(RoomBehaviour room)
    {
        _groupMarker.transform.SetParent(room.transform);

        _groupMarker.transform.localPosition = Vector2.zero;
    }
}
