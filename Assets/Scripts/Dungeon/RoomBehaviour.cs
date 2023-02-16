using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomBehaviour : MonoBehaviour 
{
    [Header("Стены: Element0-Верх, Element1-Низ, Element2-Право, Element3-Лево")]
    [SerializeField] private GameObject[] walls;

    [Header("Двери: Element0-Верх, Element1-Низ, Element2-Право, Element3-Лево")]
    [SerializeField] private GameObject[] doors;

    [Header("Номер комнаты")]
    [SerializeField] private int _numberRoom;

    [Header("Номера соседних комнат в которые можно пройти")]
    public List<int> neighbors = new List<int>();

    GameController _controller;
    public event Action GroupInteract;

    private RoomInfo roomInfo;
    public int NumberRoom => _numberRoom;

    public int Difficulty { get; set; }

    private void Start()
    {
        _controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void UpdateRoom(RoomInfo roomInfo, Vector2 size)
    {
        for (int i = 0; i < roomInfo.status.Length; i++)
        {
            doors[i].SetActive(roomInfo.status[i]);

            walls[i].SetActive(!roomInfo.status[i]);
        }

        neighbors.AddRange(roomInfo.neighbours);

        _numberRoom = roomInfo.GetRoomNumber(size);

        this.roomInfo = roomInfo;
    }

    private void OnMouseDown()
    {
        Debug.Log("Выбрана комната номер " + _numberRoom);

        if (CanPass(Global.currentRoomNumber))
        {
            _controller.SetGroupMarker(this);
        }
    }
    bool CanPass(int room)
    {
        return neighbors.Contains(room);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GroupInteract?.Invoke();
    }
}
