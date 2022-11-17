using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public Vector2 size;

    public int startPos = 0;

    private int currentCell;

    private int watchTheCycle;

    private int newCell;

    List<Cell> board;

    [Header("Префаб ячейки")]
    public GameObject room;

    public Vector2 offSet;



    void Start()
    {
        
    }

    void Update()
    {

    }

    List<RoomBehaviour> GenerateDungeon()
    {
        var result = new List<RoomBehaviour>(); 

        for (int i = 0; i < board.Count; i++)
        {
            if (board[i].visited)
            {
                var newRoom = Instantiate(room, new Vector3(board[i].x * offSet.x, -board[i].y * offSet.y, 0), Quaternion.identity, transform).GetComponent<RoomBehaviour>();

                newRoom.UpdateRoom(board[board[i].ID]);

                newRoom.name += " " + board[i].x + "-" + board[i].y;

                result.Add(newRoom);
            }

        }

        return result;
    }

    public List<RoomBehaviour> MazeGenerator()
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell() { x = j, y = i, ID = Mathf.FloorToInt(j + i * size.x) });
            }
        }

        currentCell = startPos;

        Stack<int> path = new Stack<int>();

        watchTheCycle = 0;

        while (watchTheCycle < 50)
        {
            watchTheCycle++;

            board[currentCell].visited = true;


            // Последняя ячейка
            if (currentCell == board.Count - 1)
            {
                break;
            }

            //дальше проверяем соседние ячейки в CheckNeighborsCell, после проверки помещаем в коллекцию
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
                    //нижнюю или правую
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
                    // верхнюю или левую
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
        

        return GenerateDungeon();

    }

    List<int> TakeNeighborsCells(int cell)
    {
        List<int> neighbors = new List<int>();

        //Прверяем верхнюю ячейку
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        //Прверяем нижнюю ячейку
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        //Прверяем правую ячейку
        if ((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //Прверяем левую ячейку
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}
