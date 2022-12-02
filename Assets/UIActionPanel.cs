using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIActionPanel : MonoBehaviour
{
    [SerializeField] private Text[] _enemiesTexts;
    [SerializeField] private Image[] _poses;
    [SerializeField] private Image[] _effects;
    [SerializeField] private Image actorPose;
    [SerializeField] private Image actorEffect;
    [SerializeField] private GameObject panel;

    public event Action ActionEnd;

    void Awake()
    {
        panel.SetActive(false);
    }
    public void ShowCommandResult(CommandResult commandResult)
    {
        panel.SetActive(true);
        StartCoroutine(showCommandResult(commandResult));
    }
    private void Show(CommandResult commandResult)
    {
        Clear();
        for (var i = 0; i < _enemiesTexts.Length; i++)
        {
            var index = i + 6;
            if (commandResult.TargetStates.ContainsKey(index))
            {
                var state = commandResult.TargetStates[index];
                var healthChanged = state.HealthChanged.ToString();
                _enemiesTexts[i].color = Color.red;
                if (commandResult.TargetStates[index].HealthChanged > 0)
                {
                    healthChanged = "+" + healthChanged;
                    _enemiesTexts[i].color = Color.green;
                }
                if (commandResult.TargetStates[index].HealthChanged == 0)
                {
                    healthChanged = "";
                    _enemiesTexts[i].color = Color.gray;
                }

                actorPose.enabled = true;
                _poses[i].enabled = true;
                _effects[i].enabled = true;

                switch (state.Pose)
                {
                    case EntityPose.SufferingPose:
                        _poses[i].sprite = state.Target.GetSufferingPose();
                        break;

                    case EntityPose.AttackPose:
                        _poses[i].sprite = state.Target.GetAttackPose();
                        break;
                }

                switch (commandResult.ActorPose)
                {
                    case EntityPose.SufferingPose:
                        actorPose.sprite = commandResult.Actor.GetSufferingPose();
                        break;

                    case EntityPose.AttackPose:
                        actorPose.sprite = commandResult.Actor.GetAttackPose();
                        break;
                }

                _effects[i].sprite = state.Effect;
                _poses[i].sprite = state.Target.SufferingPose;
                _enemiesTexts[i].text = healthChanged;
            }
        }
    }

    private void Clear()
    {
        foreach(var text in _enemiesTexts)
        {
            text.text = "";
        }
        foreach (var pose in _poses)
        {
            pose.enabled = false;
        }
        foreach (var effect in _effects)
        {
            effect.enabled = false;
        }

        actorPose.enabled = false;
        actorEffect.enabled = false;
    }

    private void Hide()
    {
        panel.SetActive(false);
    }

    private IEnumerator showCommandResult(CommandResult commandResult)
    {
        Show(commandResult);
        yield return new WaitForSeconds(2f);
        Hide();
        ActionEnd?.Invoke();
    }
}
