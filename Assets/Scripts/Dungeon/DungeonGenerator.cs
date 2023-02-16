using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class DungeonGenerator
{
    [SerializeField] private int startPos = 0;

    private Vector2 size;

    private int currentCell;

    private int watchTheCycle;

    private int newCell;

    private List<Cell> board;

    public Vector2 Size => size;

    

    public List<RoomInfo> GenerateMaze(Vector2 size)
    {
        this.size = size;
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell(j, i));
            }
        }

        currentCell = startPos;

        Stack<int> path = new Stack<int>();

        watchTheCycle = 0;

        while (watchTheCycle < 50)
        {
            watchTheCycle++;

            board[currentCell].visited = true;

            if (currentCell == board.Count - 1)
            {
                break;
            }

            List<int> neighbors = TakeNeighborsCells(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                newCell = neighbors[Random.Range(0, neighbors.Count)];

                board[currentCell].AddNeighbors(newCell);

                board[newCell].AddNeighbors(currentCell);

                if (newCell > currentCell)
                {
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;

                        currentCell = newCell;

                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;

                        currentCell = newCell;

                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;

                        currentCell = newCell;

                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;

                        currentCell = newCell;

                        board[currentCell].status[1] = true;
                    }
                }
            }
        }

        var roomInfos = board.Where(x => x.visited).Select(x => x.RoomInfo).ToList();

        for (int i = 0; i < roomInfos.Count; i++)
        {
            if (i > 0)
            {
                roomInfos[i].InitEnemies(size);
            }
        }
        
        return roomInfos;
    }

    List<int> TakeNeighborsCells(int cell)
    {
        List<int> neighbors = new List<int>();

        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        if ((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}
