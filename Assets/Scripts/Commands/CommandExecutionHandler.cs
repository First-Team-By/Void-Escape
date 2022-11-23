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
        int currentButton = 0;
        foreach (var command in entity.Commands)
        {
            battleButtons[currentButton].onClick.AddListener(delegate { battleRoutine.GetAvaliableTargets(command); });
            battleButtons[currentButton].image.sprite = command.Icon;
            currentButton++;
        }

        // REDO turning off ultimate button if it doesn't exist in entity command pool
        //if (currentButton < battleButtons.Length - 1)
        //{
        //    battleButtons[currentButton + 1].gameObject.SetActive(false);
        //}
    }
}
