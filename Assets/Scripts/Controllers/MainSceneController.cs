using System.ComponentModel.Design;
using System.Linq;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
	[SerializeField] UIResourceWindow _resourceWindow;
	void Awake()
	{
		if (Global.Stage == GameStage.InMission)
		{
			EndMission();
			Global.Stage = GameStage.OnBase;
		}
		
		if (Global.Stage == GameStage.StartNewGame)
		{
			Global.RefreshQuests();
		}
	}

	private void TimeTick()
	{
		foreach (var character in Global.CurrentGroup.CurrentCharacterInfos)
		{
			var currentCharacter = Global.AllCharacters.CharacterInfos.FirstOrDefault(x => x.Id == character.Id);

			currentCharacter = character;
			currentCharacter.Conditions.DropTemporaryConditions();
		}

		var idleCharacters = Global.AllCharacters.CharacterInfos
								.Where(x =>
								!Global.CurrentGroup.CurrentCharacterInfos.Select(y => y.Id).Contains(x.Id)
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
		
		foreach (var capsule in Global.Capsules)
		{
			capsule.RollStatus();			
		}

		Global.RefreshQuests();
	}
	
	private void EndMission()
	{
		Global.Storage.TransferFromInventory();
		Global.CurrentGroup.CurrentCharacterInfos.Clear();
		TimeTick();
	}
}
