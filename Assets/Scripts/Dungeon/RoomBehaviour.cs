using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomBehaviour : MonoBehaviour 
{
    [Header("�����: Element0-����, Element1-���, Element2-�����, Element3-����")]
    [SerializeField] private GameObject[] walls;

    [Header("�����: Element0-����, Element1-���, Element2-�����, Element3-����")]
    [SerializeField] private GameObject[] doors;

    [Header("����� �������")]
    [SerializeField] private int _numberRoom;

    [Header("������ �������� ������ � ������� ����� ������")]
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
        Debug.Log("������� ������� ����� " + _numberRoom);

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
