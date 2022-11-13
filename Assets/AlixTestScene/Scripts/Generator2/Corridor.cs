using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor 
{
    private Room room1;

    private Room room2;

    private CorridorOrientation orientation;

    public Corridor(Room room1, Room room2)
    {
        this.room1 = room1;

        this.room2 = room2;

        if (room1.Coords.x != room2.Coords.x)
        {
            orientation = CorridorOrientation.Horizontal;
        }
        else
        {
            orientation = CorridorOrientation.Vertical;
        }
    }

    public Room Room1 { get => room1; }
    public Room Room2 { get => room2; }
    public CorridorOrientation Orientation { get => orientation; }
}

public enum CorridorOrientation
{
    Vertical,

    Horizontal
}
