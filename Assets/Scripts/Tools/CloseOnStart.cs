using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnStart : MonoBehaviour
{
    private void Start()
    {
    	gameObject.SetActive(false);
    }
}
