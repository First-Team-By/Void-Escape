using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public bool visited = false;

    public bool[] status = new bool[4];

    public int x, y;

    public int ID;

    public List<int> neighbors = new List<int>();

    public void AddNeighbors(int id)
    {
        if (!neighbors.Contains(id))
            neighbors.Add(id);
    }
}
