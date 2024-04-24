using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattlePosition : MonoBehaviour
{
	private BattleRoutine battleRoutine;
	public EntityContainer entityContainer;
	[SerializeField] private SpriteRenderer _flare;
	[SerializeField] private int _position;
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Image _healthBar;
	[SerializeField] private Text _conditionEffectText;
	[SerializeField] private Image _bloodConditionIcon;
	[SerializeField] private Image _poisonConditionIcon;
	[SerializeField] private Image _burningConditionIcon;
    [SerializeField] private Image _fearedConditionIcon;


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
			battleRoutine.SelectTargets(Position);
		}

		if (battleRoutine.EntitiesRoute.Any(x => x.Position == _position))
		{
			battleRoutine.FillBattleInfo(Position);
		}
	}

	private void OnMouseExit()
	{
		battleRoutine.DeSelectTargets();
		battleRoutine.CurrentSelectedTargets.Clear();
	}

	private void OnMouseDown()
	{
		if (Global.UIIntersect) return;
		
		battleRoutine.OnTargetClick();
	}

	public void LightOn()
	{
		_flare.enabled = true;
	}

	public void LightOff()
	{
		_flare.enabled = false;
	}

	public void Show(bool isOn)
	{
		spriteRenderer.enabled = isOn;
	}

	public void SetHealth(float percent)
	{
		_healthBar.fillAmount = percent;
		var character = GetComponentInChildren<EntityContainer>();
		if (character)
		{
			_healthBar.transform.localPosition = new Vector2(0, character.EntityInfo.FullFaceSprite.bounds.center.y * 2 + 0.15f);
		}
		_healthBar.gameObject.SetActive(percent > 0);
	}

	public void ShowConditions(EntityConditions conditions)
	{
		_bloodConditionIcon.gameObject.SetActive(conditions.IsBleeding);
		_poisonConditionIcon.gameObject.SetActive(conditions.IsPoisoned);
		_burningConditionIcon.gameObject.SetActive(conditions.IsBurning);
		_fearedConditionIcon.gameObject.SetActive(conditions.IsFeared);
	}

	public void ShowConditionEffect(float changed, string reason)
	{
		if (changed < 0) 
		{
			_conditionEffectText.color = Color.red;
		}
		else
			_conditionEffectText.color = Color.green;
		_conditionEffectText.text = reason + " ";  
		if (changed != 0)
		{
			_conditionEffectText.text += changed;

        }
	}

	internal void ClearCondition()
	{
		_conditionEffectText.text = "";
	}
}
