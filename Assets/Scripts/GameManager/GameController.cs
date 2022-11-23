using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private DungeonGenerator _dungeonGenerator;

    private List<RoomBehaviour> _rooms;

    [SerializeField] private GameObject _groupMarkerPrefab;

    private Vector3 clickMousePoint;

    private GameObject _groupMarker;

    private bool _isOnMouseEnter = false;

    void Start()
    {
        _groupMarker = Instantiate(_groupMarkerPrefab, Vector2.zero, Quaternion.identity);

        _rooms = _dungeonGenerator.MazeGenerator();

        Global.currentRoomNumber = 0;

        //SetGroupMarker(_rooms[0]);
    }

    void Update()
    {
        if (_isOnMouseEnter)
        {
            if (Input.GetMouseButton(0))
            {
                SetClickMous();

                SetGroupMarker();

                //StartCoroutine(MoveToTarget(_groupMarkerPrefab.transform, clickMousePoint));
            }
            _isOnMouseEnter = false;
        }
    }

    private void SetClickMous()
    {
        clickMousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickMousePoint.z = 0;
    }

    public void SetGroupMarker()
    {
        StartCoroutine(MoveToTarget(_groupMarker.transform, clickMousePoint));

        //_groupMarkerPrefab.transform.SetParent(room.transform);

        //_groupMarkerPrefab.transform.localPosition = Vector2.zero;
    }

    public IEnumerator MoveToTarget(Transform obj, Vector3 point)
    {
        Vector3 startPosition = obj.position;

        float t = 0;

        const float animDuration = 0.5f;

        while (t < 1)
        {
            obj.position = Vector3.Lerp(startPosition, point, t);

            t += Time.deltaTime / animDuration;

            yield return null;
        }

        Debug.Log("Загружаем сцену с боевкой!");
    }

    public bool IsOnMouseEnter(bool a)
    {
        return _isOnMouseEnter = a;
    }
}
