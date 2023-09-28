using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
	[SerializeField] private GameObject _teamInitWindow;
	private void OnMouseDown()
	{
		if (!Global.UIIntersect)
		{
			StartCoroutine(SceneLoading());
		}
	}

	private IEnumerator SceneLoading()
	{
		yield return new WaitForSeconds(0.5f);

		_teamInitWindow.SetActive(true);
	}
}
