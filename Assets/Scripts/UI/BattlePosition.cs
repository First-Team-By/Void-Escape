using System.Collections;
using System.Collections.Generic;
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
        if (battleRoutine.CurrentAvaliableTargets != null)
        {
            //_light.enabled = battleRoutine.CurrentAvaliableTargets.Contains(Position);
            battleRoutine.SelectTargets(_position);
        }
    }

    private void OnMouseExit()
    {
        //_light.enabled = false;
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
