using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattlePosition : MonoBehaviour
{
    private BattleRoutine battleRoutine;
    [SerializeField] private Light _light;
    [SerializeField] private int _position;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _conditionEffectText;
    [SerializeField] private Image _bloodConditionIcon;
    [SerializeField] private Image _poisonConditionIcon;


    public int Position => _position;
    void Start()
    {
        battleRoutine = GameObject.FindObjectOfType<BattleRoutine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void Show(bool isOn)
    {
        spriteRenderer.enabled = isOn;
    }

    public void SetHealth(float percent)
    {
        _healthBar.fillAmount = percent;
        _healthBar.gameObject.SetActive(percent > 0);
    }

    public void SetConditions(EntityConditions conditions)
    {
        _bloodConditionIcon.gameObject.SetActive(conditions.IsBleeding);
        _poisonConditionIcon.gameObject.SetActive(conditions.IsPoisoned);
    }

    public void ShowConditionHealthChanging(float changed, string reason)
    {
        if (changed < 0) 
        {
            _conditionEffectText.color = Color.red;
        }
        else
            _conditionEffectText.color = Color.green;
        _conditionEffectText.text = reason + " " + changed;        
    }

    internal void ClearCondition()
    {
        _conditionEffectText.text = "";
    }
}
