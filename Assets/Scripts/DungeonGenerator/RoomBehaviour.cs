using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Выбрана комната номер " + _numberRoom);

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
