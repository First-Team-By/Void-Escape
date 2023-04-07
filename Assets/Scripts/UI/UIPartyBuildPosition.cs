using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPartyBuildPosition : UIDragAndDrop, IDropHandler
{
    [SerializeField] private int position;
    public int Position => position;
    public UICharacterSlot CharacterSlot { get; set; }
    public Sprite CharacterSprite { get; set; }
    public Image CharacterImage { get; set; }
    
    private RaycastResult currentRayCast;
    private UIPartyBuildGameManager gameManager;
    public bool IsFree { get; set; } = true;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        CharacterImage = GetComponent<Image>();
        gameManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        CharacterImage.raycastTarget = false;
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);


        currentRayCast = eventData.pointerCurrentRaycast;
        var freePosition = currentRayCast.gameObject.GetComponent<UIPartyBuildPosition>();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        CharacterImage.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var characterSlot = eventData.pointerDrag.gameObject.GetComponent<UICharacterSlot>();
        var position = eventData.pointerDrag.gameObject.GetComponent<UIPartyBuildPosition>();

        if (position != null && IsFree)
        {
            CharacterSlot = position.CharacterSlot;
            CharacterImage.sprite = position.CharacterImage.sprite;
            position.CharacterImage.color = new Color(255, 255, 255, 0);
            CharacterImage.color = new Color(255, 255, 255, 255);
            position.CharacterImage.sprite = null;
            IsFree = false;
            position.IsFree = true;

            var currentCharacter =
                Global.currentGroup.CurrentCharacterInfos.FirstOrDefault(x => x.Position == position.Position);
            currentCharacter.Position = Position;
        }

        if (characterSlot != null && IsFree)
        {
            CharacterSlot = characterSlot;
            CharacterImage.sprite = characterSlot.CharacterInfo.FullFaceSprite;
            CharacterImage.color = new Color(255, 255, 255, 255);
            gameManager.CharacterSlots.Add(characterSlot);
            characterSlot.transform.gameObject.SetActive(false);
            IsFree = false;

            var currentCharacter =
                Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == characterSlot.CharacterId);

            currentCharacter.Position = Position;
            Global.currentGroup.CurrentCharacterInfos.Add(currentCharacter);
        }
    }
}
