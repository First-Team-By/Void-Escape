using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePosition : MonoBehaviour
{
    private BattleRoutine battleRoutine;
    [SerializeField] private Light _light;
    [SerializeField] private int Position;
    void Start()
    {
        battleRoutine = GameObject.FindObjectOfType<BattleRoutine>();
    }

    private void OnMouseEnter()
    {
        if (battleRoutine.CurrentAvaliableTargets != null)
        {
            _light.enabled = battleRoutine.CurrentAvaliableTargets.Contains(Position);
        }
    }

    private void OnMouseExit()
    {
        _light.enabled = false;
    }


}
