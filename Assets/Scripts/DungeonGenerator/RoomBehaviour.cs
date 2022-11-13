using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    [Header("Стены: Element0-Верх, Element1-Низ, Element2-Право, Element3-Лево")]
    [SerializeField] private GameObject[] walls;

    [Header("Двери: Element0-Верх, Element1-Низ, Element2-Право, Element3-Лево")]
    [SerializeField] private GameObject[] doors;

    [Header("Номер текущей комнаты")]
    [SerializeField] private int _numberRoom;

    [Header("Номера соседних комнат в которые можно пройти")]
    public List<int> neighbors = new List<int>();

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
}
