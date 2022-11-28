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

    public void ShowCommandResult(CommandResult commandResult)
    {
        gameObject.SetActive(true);
        StartCoroutine(showCommandResult(commandResult));
    }
    private void Show(CommandResult commandResult)
    {
        Clear();
        //_text.text = commandResult.ResultText;
        for (var i = 0; i < _enemiesTexts.Length; i++)
        {
            var index = i + 6;
            if (commandResult.TargetStates.ContainsKey(index))
            {
                var state = commandResult.TargetStates[index];
                var healthChanged = state.HealthChanged.ToString();
                if (commandResult.TargetStates[index].HealthChanged > 0)
                {
                    healthChanged = "+" + healthChanged;
                }
                if (commandResult.TargetStates[index].HealthChanged == 0)
                {
                    healthChanged = "";
                }

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
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator showCommandResult(CommandResult commandResult)
    {
        Show(commandResult);
        yield return new WaitForSeconds(2f);
        Hide();
    }
}
