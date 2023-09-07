using System.Linq;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    void Start()
    {
        if (Global.Stage == GameStage.InMission)
        {
            LoadAfterMission();
            Global.Stage = GameStage.OnBase;
        }
    }

    private void LoadAfterMission()
    {
        foreach (var character in Global.currentGroup.CurrentCharacterInfos)
        {
            var currentCharacter = Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == character.Id);

            currentCharacter = character;
            currentCharacter.Conditions.DropTemporaryConditions();
            
        }

        var idleCaracters = Global.allCharacters.CharacterInfos
                                            .Where(x =>
                                            !Global.currentGroup.CurrentCharacterInfos.Select(y => y.Id).Contains(x.Id)
                                             );
        foreach (var character in idleCaracters)
        {
            character.Conditions.DecreaseConstantCondition();
        }

        Global.currentGroup.CurrentCharacterInfos.Clear();

        Global.storage.TransferFromInventory();
    }
}
