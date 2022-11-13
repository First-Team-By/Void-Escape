using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    [Header("�����: Element0-����, Element1-���, Element2-�����, Element3-����")]
    [SerializeField] private GameObject[] walls;

    [Header("�����: Element0-����, Element1-���, Element2-�����, Element3-����")]
    [SerializeField] private GameObject[] doors;

    [Header("����� ������� �������")]
    [SerializeField] private int _numberRoom;

    [Header("������ �������� ������ � ������� ����� ������")]
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
