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

    public void ShowCondition(string text)
    {
        _conditionEffectText.text = text;
    }
}
