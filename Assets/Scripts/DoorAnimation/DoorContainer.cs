using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private GameObject _topDoor;

    [SerializeField] private GameObject _bottomDoor;

    [SerializeField] private GameObject _door;

    [SerializeField] private GameObject _window;

    private SpriteRenderer _topDoorSR;

    private SpriteRenderer _bottomDoorSR;

    private Image _imageDoor;

    [SerializeField] private Animator _anim;



    private void Start()
    {
        _topDoorSR = _topDoor.GetComponent<SpriteRenderer>();
        _bottomDoorSR = _bottomDoor.GetComponent<SpriteRenderer>();
        _anim = _door.GetComponent<Animator>();
        _imageDoor = _topDoor.GetComponent<Image>(); 
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _imageDoor.color = Color.gray;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _anim.SetBool("isOpen", true);

        StartCoroutine(WindowsLoading());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _imageDoor.color = Color.white;

        _anim.SetBool("isOpen", false);
    }
}
