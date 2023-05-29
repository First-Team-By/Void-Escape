using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPartyBuildPosition : UIDragAndDrop
{
    [SerializeField] private int position;
    [SerializeField] private UIDropHandler dropHandler;
    [SerializeField] private Image positionImage;
    public int Position => position;
    public UICharacterSlot CharacterSlot { get; set; }
    public Sprite CharacterSprite { get; set; }
    public Image CharacterImage { get; set; }
    public CharacterInfo Character { get; set; }
    public UIDropHandler DropHandler => dropHandler;
    
    private RaycastResult currentRayCast;
    private UIPartyBuildGameManager partyManager;
    public bool IsFree { get; set; } = true;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();

        CharacterImage = GetComponent<Image>();
        partyManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();

        dropHandler.OnDropEvent += OnDropHandler;
        dropHandler.OnPointerEnterEvent += OnPointerEnterHandler;
        dropHandler.OnPointerEnterEvent += OnPointerExitHandler;
    }

    private void OnDestroy()
    {
        dropHandler.OnDropEvent -= OnDropHandler;
        dropHandler.OnPointerEnterEvent -= OnPointerEnterHandler;
        dropHandler.OnPointerEnterEvent -= OnPointerExitHandler;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (IsFree)
        {
            return;
        }

        base.OnBeginDrag(eventData);

        CharacterImage.raycastTarget = false;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        CharacterImage.raycastTarget = true;
    }

    private void OnDropHandler(PointerEventData eventData)
    {
        var characterSlot = eventData.pointerDrag.gameObject.GetComponent<UICharacterSlot>();
        var position = eventData.pointerDrag.gameObject.GetComponent<UIPartyBuildPosition>();

        if (position != null && IsFree && !position.IsFree)
        {
            CharacterSlot = position.CharacterSlot;
            Character = CharacterSlot.Character;
            CharacterImage.sprite = position.CharacterImage.sprite;
            position.CharacterImage.color = new Color(255, 255, 255, 0);
            CharacterImage.color = new Color(255, 255, 255, 255);
            position.CharacterImage.sprite = null;
            IsFree = false;
            position.IsFree = true;

            var currentCharacter =
                Global.currentGroup.CurrentCharacterInfos.FirstOrDefault(x => x.Position == position.Position);
            currentCharacter.Position = Position;

            position.DropHandler.Container.raycastTarget = true;
            position.CharacterImage.raycastTarget = false;
            CharacterImage.raycastTarget = true;
            DropHandler.Container.raycastTarget = false;
        }

        if (characterSlot != null && IsFree)
        {
            CharacterSlot = characterSlot;
            Character = CharacterSlot.Character;
            CharacterImage.sprite = characterSlot.CharacterInfo.FullFaceSprite;
            CharacterImage.color = new Color(255, 255, 255, 255);
            partyManager.CharacterSlots.Add(characterSlot);
            characterSlot.transform.gameObject.SetActive(false);
            IsFree = false;
            
            var currentCharacter =
                Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == characterSlot.CharacterId);

            currentCharacter.Position = Position;
            Global.currentGroup.CurrentCharacterInfos.Add(currentCharacter);

            CharacterImage.raycastTarget = true;
            DropHandler.Container.raycastTarget = false;
            
        }
    }

    

    public void OnPointerEnterHandler(PointerEventData eventData)
    {
        if (IsFree) {
            positionImage.color = new Color(1, 0, 0, 1);
        }  
    }

    public void OnPointerExitHandler(PointerEventData eventData)
    {
        positionImage.color = new Color(0, 1, 0, 1);
    }
}
