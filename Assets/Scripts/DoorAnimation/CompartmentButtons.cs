using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompartmentButtons : MonoBehaviour
{
	[SerializeField] private GameObject _window;

	public void CloseWindow()
	{
		_window.SetActive(false);
	}
}
