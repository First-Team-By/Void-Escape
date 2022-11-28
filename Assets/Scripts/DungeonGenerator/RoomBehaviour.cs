using System.Collections;
using System.Collections.Generic;
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

    //[SerializeField] private Light _light;

    GameController _controller;

    private void Start()
    {
        _controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void UpdateRoom(Cell cell)
    {
        for (int i = 0; i < cell.status.Length; i++)
        {
            doors[i].SetActive(cell.status[i]);

            walls[i].SetActive(!cell.status[i]);
        }

        _numberRoom = cell.ID;

        neighbors.AddRange(cell.neighbors);
    }

    private void OnMouseDown()
    {
        Debug.Log("������� ������� ����� " + _numberRoom);

        if (CanPass(Global.currentRoomNumber))
        {
            Global.currentRoomNumber = _numberRoom;

            _controller.SetGroupMarker(gameObject.transform);
        }
    }

    //public void OnMouseEnter()
    //{
    //    if (CanPass(Global.currentRoomNumber))
    //    {
    //        _light.enabled = true;
    //    }
    //}

    //public void OnMouseExit()
    //{
    //    _light.enabled = false;
    //}

    bool CanPass(int room)
    {
        return neighbors.Contains(room);
    }
}
