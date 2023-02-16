using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;

public class Cell 
{
    public bool visited = false;

    public RoomInfo RoomInfo { get; set; } = new RoomInfo();
    //public bool[] status = new bool[4];

    //public int x, y;

    //public List<int> neighbors = new List<int>();
    public bool[] status => RoomInfo.status;

    public int x => RoomInfo.x;
    public int y => RoomInfo.y;

    public List<int> neighbours => RoomInfo.neighbours;

    public Cell(int x, int y)
    {
        RoomInfo.x = x;
        RoomInfo.y = y;
    }

    public void AddNeighbors(int id)
    {
        if (!neighbours.Contains(id))
            neighbours.Add(id);
    }

    
}
