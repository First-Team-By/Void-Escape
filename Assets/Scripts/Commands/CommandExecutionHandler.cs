using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandExecutionHandler : MonoBehaviour
{
    private Toggle[] battleButtons;
    [SerializeField] BattleRoutine battleRoutine;
    void Awake()
    {
        battleButtons = GetComponentsInChildren<Toggle>()
            //.Where(x => x.gameObject.TryGetComponent<CommandButton>(out _))
            .ToArray();
    }
    public void SetCommands(EntityBase entity)
    {
        HideBattleButtons();

        int currentButton = 0;
        foreach (var command in entity.Commands)
        {
            var button = battleButtons[currentButton];
            button.onValueChanged.AddListener(delegate { battleRoutine.SetCurrentCommand(command); });
            button.image.sprite = command.Icon;
            button.gameObject.SetActive(true);

            currentButton++;
        }
        battleRoutine.SetCurrentCommand(entity.Commands[currentButton - 1]);
        battleButtons[currentButton - 1].isOn = true;

        CheckOffBattleButtons();
    }

    private void HideBattleButtons()
    {
        foreach (var button in battleButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
    private void CheckOffBattleButtons()
    {
        foreach (var button in battleButtons)
        {
            button.isOn = false;
        }
    }
}
