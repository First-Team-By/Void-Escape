using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
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

        SceneManager.LoadScene(2); // TeamInitScene
    }
}
