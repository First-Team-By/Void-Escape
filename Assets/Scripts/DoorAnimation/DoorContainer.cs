using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] _doorparts;

    [SerializeField] private GameObject _window;

    private List<SpriteRenderer> _doorPartsSR;

    private Animator _anim;

	private void Start()
    {
        _anim = GetComponent<Animator>();

        _doorPartsSR = new List<SpriteRenderer>();

        foreach (var item in _doorparts)
        {
            _doorPartsSR.Add(item.GetComponent<SpriteRenderer>());
        }
    }

    private void OnMouseEnter()
    {
        foreach (var item in _doorPartsSR)
        {
            item.color = Color.gray;
        }
    }

    private void OnMouseExit()
    {
        foreach (var item in _doorPartsSR)
        {
            item.color = Color.white;
        }

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

        try
        {
            _window.SetActive(true);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
}

