using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIBattleResultCard : MonoBehaviour
{
    [SerializeField] private UIResourceCard _resourceCardPrefab;
    [SerializeField] private Transform _resourceCardsContainer;
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

        var lootedResources = loot.Items.Where(x => x.Type.IsSubclassOf(typeof(ResourceItem))).ToList();
        foreach (var resource in lootedResources)
        {
            var instance = GameObject.Instantiate(_resourceCardPrefab, _resourceCardsContainer);
            instance.Amount = resource.Amount.ToString();
            instance.Icon = (resource.GetItem() as ResourceItem).Icon;
        }

        var lootedEquipment = loot.Items.Where(x => x.Type.IsSubclassOf(typeof(Equipment))).ToList();
        foreach (var equipment in lootedEquipment)
        {
            var instance = GameObject.Instantiate(_resourceCardPrefab, _resourceCardsContainer);
            instance.Icon = (equipment.GetItem() as Equipment).Icon;
            instance.Amount = "1";
        }
    }
}
