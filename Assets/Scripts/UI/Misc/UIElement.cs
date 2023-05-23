using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElement : MonoBehaviour
{
    private void OnEnable()
    {
        Global.UIIntersect = true;
    }

    private void OnDisable()
    {
        Global.UIIntersect = false;
    }
}
