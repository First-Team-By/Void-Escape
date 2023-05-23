using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResourceCard : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _amountText;

    public Sprite Icon
    {
        get => _icon.sprite;
        set => _icon.sprite = value;
    }

    public string Amount
    {
        get => _amountText.text;
        set => _amountText.text = value.ToString();
    }
}
