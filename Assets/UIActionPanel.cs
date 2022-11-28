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
        //_text.text = commandResult.ResultText;
        for (var i = 0; i < _enemiesTexts.Length; i++)
        {
            Debug.Log(commandResult.TargetStates.Keys.Count + "keys");
            var healthChanged = commandResult.TargetStates[i + 6].HealthChanged.ToString();
            if (commandResult.TargetStates[i + 6].HealthChanged > 0)
            {
                healthChanged = "+" + healthChanged;
            }
            _enemiesTexts[i].text = healthChanged;
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
