using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterSlotsContainer : MonoBehaviour, IDropHandler
{
    private UIPartyBuildGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var uiPosition = eventData.pointerDrag.GetComponent<UIPartyBuildPosition>();
        if (uiPosition != null)
        {
            UICharacterSlot slot = gameManager.CharacterSlots.Find(x => x == uiPosition.CharacterSlot);
            slot.gameObject.SetActive(true);
            slot.ServiceImagePanel.gameObject.SetActive(true);
            slot.GetComponent<Image>().color = new Color(69, 136, 140, 255);

            uiPosition.CharacterImage.color = new Color(255, 255, 255, 0);
            uiPosition.CharacterImage.sprite = null;
            uiPosition.IsFree = true;
            uiPosition.DropHandler.Container.raycastTarget = true;

            var currentCharacter =
                Global.currentGroup.CurrentCharacterInfos.FirstOrDefault(x => x.Position == uiPosition.Position);

            Global.currentGroup.CurrentCharacterInfos.Remove(currentCharacter);

            
        }
    }
}
