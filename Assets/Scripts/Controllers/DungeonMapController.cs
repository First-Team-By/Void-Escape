using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MissionState
{
	Start,
	ReturnFromBattle
}

public class DungeonMapController : MonoBehaviour
{
	[SerializeField] private GameObject _mapContent;

	[SerializeField] private GameObject _groupMarkerPrefab;

	[SerializeField] private Transform _startPoint;

	[SerializeField] private float _speed;

	private List<RoomBehaviour> _rooms;

	private GameObject _groupMarker;

	private Vector3 startPosition;

	private bool _groupIsMoving;

	[SerializeField] private EventResolver eventResolver;

	[Header("������ ������")]
	[SerializeField] private GameObject room;

	[SerializeField] private Vector2 offSet;

	[SerializeField] private Transform roomNest;
	[SerializeField] private Button completeMissionButton; 
	[SerializeField] private Button abortMissionButton;
	[SerializeField] private float maxScrollValue; 
	[SerializeField] private float minScrollValue; 
	

	public Vector2 Size { get; set; }

	void Start()
	{
		Size = Global.currentMapInfo.Size;  
		
		_groupMarker = Instantiate(_groupMarkerPrefab, Vector2.zero, Quaternion.identity);

		if (Global.currentMapInfo.missionState == MissionState.Start)
		{
			var dungeonGenerator = new DungeonGenerator();

			var roomInfos = dungeonGenerator.GenerateMaze(Size);
			//Global.currentMapInfo.RoomInfos = roomInfos;
			_rooms = GenerateDungeon(roomInfos);
			_groupMarker.transform.parent = _rooms[0].transform;
			_groupMarker.transform.localPosition = Vector2.zero;
			Global.currentMapInfo.MapQuest.Initialize(Global.currentMapInfo);
		}
		else
		{
			_rooms = GenerateDungeon(Global.currentMapInfo.RoomInfos);
			
			_groupMarker.transform.SetParent(_rooms.First(x => x.NumberRoom == Global.currentMapInfo.currentRoomNumber).transform);
			_groupMarker.transform.localPosition = Vector3.zero;
			
			completeMissionButton.gameObject.SetActive(Global.currentMapInfo.MapQuest.Status == QuestStatus.Completed);
			abortMissionButton.gameObject.SetActive(!completeMissionButton.gameObject.activeSelf);
		}
	}

	void Update()
	{
		float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

		var newScale = _mapContent.transform.localScale + new Vector3(wheelScroll, wheelScroll, 0);
		
		if (wheelScroll != 0 && newScale.x > minScrollValue && newScale.x <= maxScrollValue)
		{
			_mapContent.transform.localScale = newScale;
		}
	}
	public void SetGroupMarker(RoomBehaviour room)
	{
		if (!_groupIsMoving)
		{
			Global.currentMapInfo.currentRoomNumber = room.NumberRoom;

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
		}

		finally
		{ 
			_groupIsMoving = false; 
		}
	}

	private List<RoomBehaviour> GenerateDungeon(List<RoomInfo> board)
	{
		var result = new List<RoomBehaviour>();

		for (int i = 0; i < board.Count; i++)
		{
			var newRoom = Instantiate(room, new Vector3(board[i].x * offSet.x, -board[i].y * offSet.y, 0), Quaternion.identity, roomNest).GetComponent<RoomBehaviour>();
			newRoom.GroupInteract += eventResolver.OnEventResolve;

			
			newRoom.UpdateRoom(board[i], Size);

			newRoom.name += " " + board[i].x + "-" + board[i].y;


			result.Add(newRoom);
		}

		//result[0].GetComponent<Collider2D>().enabled = false;
		return result;
	}

	public void AbortMission()
	{
		SceneManager.LoadScene(1); // MainScene
	}
}
