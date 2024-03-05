using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContainmentController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	[SerializeField] private Outline _outLine;
	[SerializeField] private CompartmentType _compartmentType;
	private Compartment _compartment;
	public Compartment Compartment => _compartment; 
	public bool IsSelected { get; set; }
	public Action<ContainmentController> Selected;

	private void Awake()
	{
		switch (_compartmentType)
		{
			case CompartmentType.CrewQuarters:
				_compartment = Global.Compartments.First(x => x.GetType() == typeof(LowerDecks));
				break;
				
			case CompartmentType.ReactorChamber:
				_compartment = Global.Compartments.First(x => x.GetType() == typeof(ReactorChamber));
				break;
		}
	}
	
	public void Select(bool value)
	{
		IsSelected = value;
		_outLine.enabled = value;
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{
		Selected?.Invoke(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_outLine.enabled = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!IsSelected)
		{
			_outLine.enabled = false;
		}
	}
}
