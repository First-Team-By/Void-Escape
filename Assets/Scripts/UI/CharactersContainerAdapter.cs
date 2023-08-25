using System.Linq;
using UnityEngine;

public class CharactersContainerAdapter : MonoBehaviour
{
    [SerializeField] private GameObject _characterSlotPrefab;

    [SerializeField] private RectTransform _contentMedCharPanel;

    private void OnEnable()
    {
        foreach (Transform item in _contentMedCharPanel.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var characterInfo in Global.allCharacters.CharacterInfos.Where(x => x.MedicalState == MedicalState.Idle))
        {
            var characterSlot = GameObject.Instantiate(_characterSlotPrefab.gameObject) as GameObject;
            var uiCharacterSlot = characterSlot.GetComponent<UICharacterSlot>();    
            uiCharacterSlot.CharacterInfo = characterInfo;

            uiCharacterSlot.Portrait.sprite = characterInfo.FullFaceSprite;

            uiCharacterSlot.CharacterId = characterInfo.Id;
            characterSlot.transform.SetParent(_contentMedCharPanel, false);

            uiCharacterSlot.CharacterName.text = EnemyInfo.GetClassName(characterInfo.EntityClass);
        }
    }
}
