using System.ComponentModel.Design;
using System.Linq;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
	void Start()
	{
		if (Global.Stage == GameStage.InMission)
		{
			EndMission();
			Global.Stage = GameStage.OnBase;
		}
	}

	private void TimeTick()
	{
		foreach (var character in Global.currentGroup.CurrentCharacterInfos)
		{
			var currentCharacter = Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == character.Id);

			currentCharacter = character;
			currentCharacter.Conditions.DropTemporaryConditions();
		}

		var idleCharacters = Global.allCharacters.CharacterInfos
								.Where(x =>
								!Global.currentGroup.CurrentCharacterInfos.Select(y => y.Id).Contains(x.Id)
								).ToList();
		foreach (var character in idleCharacters)
		{
			character.Conditions.DecreaseConstantCondition();
		}

		var patients = idleCharacters.Where(x => x.MedicalState != MedicalState.Idle).ToList();
		foreach (var patient in patients)
		{
			patient.ApplyMedication();
		}
	}
	
	private void EndMission()
	{
		Global.storage.TransferFromInventory();
		Global.currentGroup.CurrentCharacterInfos.Clear();
		TimeTick();
	}
}
