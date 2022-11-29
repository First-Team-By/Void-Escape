using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private DungeonGenerator _dungeonGenerator;

    [SerializeField] private GameObject _mapContent;

    [SerializeField] private GameObject _groupMarkerPrefab;

    [SerializeField] private Transform _parent;

    [SerializeField] private float _speed;

    private List<RoomBehaviour> _rooms;

    private GameObject _groupMarker;

    private Vector3 startPosition;

    private bool _groupIsMoving;

    void Start()
    {
        _groupMarker = Instantiate(_groupMarkerPrefab, Vector2.zero, Quaternion.identity);

        _groupMarker.transform.parent = _parent;
        
        _rooms = _dungeonGenerator.MazeGenerator();

        Global.currentRoomNumber = 0;
    }

    void Update()
    {
        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (wheelScroll != 0)
        {
            _mapContent.transform.localScale += new Vector3(wheelScroll, wheelScroll, 0);
        }
    }
    public void SetGroupMarker(RoomBehaviour room)
    {
        if (!_groupIsMoving)
        {
            Global.currentRoomNumber = room.NumberRoom;

            StartCoroutine(MoveToTarget(_groupMarker.transform, room.gameObject.transform));
        }    
    }

    public IEnumerator MoveToTarget(Transform obj, Transform target)
    {
        _groupIsMoving = true;

        try
        {
            obj.SetParent(target);

            startPosition = obj.localPosition;

            while (obj.localPosition != Vector3.zero)
            {
                obj.localPosition = Vector3.MoveTowards(obj.localPosition, Vector3.zero, Time.deltaTime * _speed);

                //yield return new WaitForSeconds(0.001f);
                yield return null;
            }

            Debug.Log("Загружаем сцену с боевкой!");
        }

        finally
        { 
            _groupIsMoving = false; 
        }
    }
}
