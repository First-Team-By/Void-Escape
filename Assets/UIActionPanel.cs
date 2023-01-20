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
    [SerializeField] private Text[] _charactersTexts;
    [SerializeField] private Image[] _charactersPoses;
    [SerializeField] private Image[] _enemiesPoses;
    [SerializeField] private Image[] _enemiesEffects;
    [SerializeField] private Image[] _charactersEffects;

    [SerializeField] private Image actorPose;
    [SerializeField] private Image actorEffect;
    [SerializeField] private Text actorText;
    [SerializeField] private GameObject panel;

    private Text[] EntitiesTexts => _charactersTexts.Concat(_enemiesTexts).ToArray();
    private Image[] EntitiesPoses => _charactersPoses.Concat(_enemiesPoses).ToArray();
    private Image[] EntitiesEffects => _charactersEffects.Concat(_enemiesEffects).ToArray();

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
        for (var i = 0; i < EntitiesTexts.Length; i++)
        {
            var index = i + 1;
            if (commandResult.TargetStates.ContainsKey(index))
            {
                actorText.text = null;
                var state = commandResult.TargetStates[index];
                var healthChanged = state.HealthChanged.ToString();
                EntitiesTexts[i].color = Color.red;
                actorText.color = Color.red;
                if (commandResult.TargetStates[index].HealthChanged > 0)
                {
                    healthChanged = "+" + healthChanged;
                    EntitiesTexts[i].color = Color.green;
                    actorText.color = Color.green;
                }
                if (commandResult.TargetStates[index].HealthChanged == 0)
                {
                    healthChanged = "";
                    EntitiesTexts[i].color = Color.gray;
                    actorText.color = Color.gray;
                }

                actorPose.enabled = true;
                if (commandResult.Actor.Position != index)
                {
                    EntitiesPoses[i].enabled = true;
                    EntitiesEffects[i].enabled = true;
                    EntitiesEffects[i].sprite = state.Effect;
                    EntitiesPoses[i].sprite = state.Target.SufferingPose;
                    EntitiesTexts[i].text = healthChanged;
                }
                else
                {
                    actorEffect.enabled = true;
                    actorEffect.sprite = state.Effect;
                    actorText.text = healthChanged;
                }

                if (index != commandResult.Actor.Position)
                {
                    EntitiesPoses[i].sprite = state.Target.GetPose(state.PoseName);
                    //switch (state.Pose)
                    //{
                    //    case EntityPose.SufferingPose:
                    //        EntitiesPoses[i].sprite = state.Target.GetSufferingPose();
                    //        break;

                    //    case EntityPose.AttackPose:
                    //        EntitiesPoses[i].sprite = state.Target.GetAttackPose();
                    //        break;
                    //}
                }

                actorPose.sprite = commandResult.Actor.GetPose(commandResult.ActorPoseName);
                //switch (commandResult.ActorPose)
                //{
                //    case EntityPose.SufferingPose:
                //        actorPose.sprite = commandResult.Actor.GetSufferingPose();
                //        break;

                //    case EntityPose.AttackPose:
                //        actorPose.sprite = commandResult.Actor.GetAttackPose();
                //        break;
                //}
            }
        }
    }

    private void Clear()
    {
        foreach(var text in EntitiesTexts)
        {
            text.text = "";
        }
        foreach (var pose in EntitiesPoses)
        {
            pose.enabled = false;
        }
        foreach (var effect in EntitiesEffects)
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
