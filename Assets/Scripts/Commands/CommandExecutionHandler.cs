using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandExecutionHandler : MonoBehaviour
{
    private Button[] battleButtons;
    [SerializeField] BattleRoutine battleRoutine;
    void Awake()
    {
        battleButtons = GetComponentsInChildren<Button>()
            //.Where(x => x.gameObject.TryGetComponent<CommandButton>(out _))
            .ToArray();
    }
    public void SetCommands(EntityBase entity)
    {
        OffBattleButtons();

        int currentButton = 0;
        foreach (var command in entity.Commands)
        {
            battleButtons[currentButton].onClick.AddListener(delegate { battleRoutine.SetCurrentCommand(command); });
            battleButtons[currentButton].image.sprite = command.Icon;
            battleButtons[currentButton].gameObject.SetActive(true);
            currentButton++;
        }
    }

    private void OffBattleButtons()
    {
        foreach (var button in battleButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
