using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlePosition : MonoBehaviour
{
    private BattleRoutine battleRoutine;
    [SerializeField] private Light _light;
    [SerializeField] private int _position;

    public int Position => _position;
    void Start()
    {
        battleRoutine = GameObject.FindObjectOfType<BattleRoutine>();
    }

    private void OnMouseEnter()
    {
        if (battleRoutine.CurrentAvaliableTargets is not null)
        {
            battleRoutine.SelectTargets(_position);
        }
    }

    private void OnMouseExit()
    {
        battleRoutine.DeSelectTargets();
    }

    private void OnMouseDown()
    {
        battleRoutine.OnTargetClick();
    }

    public void LightOn()
    {
        _light.enabled = true;
    }

    public void LightOff()
    {
        _light.enabled = false;
    }


}
