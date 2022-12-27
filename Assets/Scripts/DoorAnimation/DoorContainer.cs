using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContainer : MonoBehaviour
{
    [SerializeField] private GameObject _topDoor;

    [SerializeField] private GameObject _bottomDoor;

    [SerializeField] private GameObject _door;

    [SerializeField] private GameObject _window;

    private SpriteRenderer _topDoorSR;

    private SpriteRenderer _bottomDoorSR;

    private Animator _anim;



    private void Start()
    {
        _topDoorSR = _topDoor.GetComponent<SpriteRenderer>();
        _bottomDoorSR = _bottomDoor.GetComponent<SpriteRenderer>();
        _anim = _door.GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        _topDoorSR.color = Color.gray;
        _bottomDoorSR.color = Color.gray;
    }

    private void OnMouseExit()
    {
        _topDoorSR.color = Color.white;
        _bottomDoorSR.color = Color.white;

        _anim.SetBool("isOpen", false);
    }

    private void OnMouseDown()
    {
        _anim.SetBool("isOpen", true);

        StartCoroutine(WindowsLoading());
    }

    private IEnumerator WindowsLoading()
    {
        yield return new WaitForSeconds(0.5f);

        _window.SetActive(true);
    }
}
