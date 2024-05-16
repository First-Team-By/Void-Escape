using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragCharacterContainer : UIDragContainer, IPointerClickHandler
{
    public int CharacterId { get; set; }

    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private Image _deviceImage;
    [SerializeField] private Image _skill1Image;
    [SerializeField] private Image _skill2Image;
    [SerializeField] private Image _skill3Image;
    [SerializeField] private Image _skill4Image;
    public CharacterInfo Character => (CharacterInfo)_businessObject;

    public override void Initialize()
    {
        _nameText.text = Character.FullName;
        RefreshEquipment();
    }

    public void RefreshEquipment()
    {
        _weaponImage.sprite = Character.Weapon.Icon;
        _deviceImage.sprite = Character.Device != null ? Character.Device.Icon : null;
        _deviceImage.gameObject.SetActive(Character.Device != null);
        if (Character.Commands.Count > 0)
            _skill1Image.sprite = Character.Commands[0].Icon;
        _skill1Image.gameObject.SetActive(Character.Commands.Count > 0);
        if (Character.Commands.Count > 1)
            _skill2Image.sprite = Character.Commands[1].Icon;
        _skill2Image.gameObject.SetActive(Character.Commands.Count > 1);
        if (Character.Commands.Count > 2)
            _skill3Image.sprite = Character.Commands[2].Icon;
        _skill3Image.gameObject.SetActive(Character.Commands.Count > 2);
        if (Character.Commands.Count > 3)
            _skill4Image.sprite = Character.Commands[3].Icon;
        _skill4Image.gameObject.SetActive(Character.Commands.Count > 3);

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ToggleImagePanels(true);

        Debug.Log("On begin drag");
        OldParent = transform.parent;

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = false;

        transform.SetParent(_rootPanel);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        Debug.Log("OnEnDrag");


        transform.localPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;

        _canvasGroup.blocksRaycasts = true;
    }
}
