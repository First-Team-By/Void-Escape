using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIBattleResultCard : MonoBehaviour
{
    [SerializeField] private UIResourceCard _resourceCardPrefab;
    [SerializeField] private UIEquipmentCard _equipmentCardPrefab;

    [SerializeField] private Transform _resourceCardsContainer;
    [SerializeField] private Transform _equipmentCardsContainer;

    [SerializeField] private TMP_Text _battleResultText;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void FillBattleResultInfo(bool isWon, Loot loot)
    {
        gameObject.SetActive(true);
        
        if (isWon)
        {
            _battleResultText.text = "Win";
        }
        else
        {
            _battleResultText.text = "Lose";
        }

        var resources = loot.Items.Where(x => x.Type.IsSubclassOf(typeof(ResourceItem)));
        foreach (var resource in resources)
        {
            var instance = GameObject.Instantiate(_resourceCardPrefab, _resourceCardsContainer);
            instance.Amount = resource.Amount.ToString();
            instance.Icon = (resource.GetItem() as ResourceItem).Icon;
        }
    }
}
