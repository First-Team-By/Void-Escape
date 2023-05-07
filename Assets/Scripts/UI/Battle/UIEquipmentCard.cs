using UnityEngine;
using UnityEngine.UI;

public class UIEquipmentCard : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public Sprite Icon
    {
        get => _icon.sprite;
        set => _icon.sprite = value;
    }
}
