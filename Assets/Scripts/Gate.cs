using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("TeamInitScene");
    }
}
