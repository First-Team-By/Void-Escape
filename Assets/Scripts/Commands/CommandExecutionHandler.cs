using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandExecutionHandler : MonoBehaviour
{
    private Button[] battleButtons;
    void Start()
    {
        battleButtons = GetComponentsInChildren<Button>();
    }
    public void SetCommands(EntityBase entity)
    {
        int currentButton = 0;
        foreach (var command in entity.Commands)
        {
            battleButtons[currentButton].onClick.AddListener(command.OnExecute);
            currentButton++;
        }
    }
}
