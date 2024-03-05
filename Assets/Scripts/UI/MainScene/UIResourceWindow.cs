using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceWindow : MonoBehaviour
{
    [SerializeField] private UIResourceCard energyCard;
    [SerializeField] private UIResourceCard metallCard;
    [SerializeField] private UIResourceCard electronicsCard;
    [SerializeField] private UIResourceCard medicineCard;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        var resources = Global.Storage.Resources;

        energyCard.Amount = resources.Energy.ToString();
        metallCard.Amount = resources.Metal.ToString();
        electronicsCard.Amount = resources.Electronics.ToString();
        medicineCard.Amount = resources.Medicine.ToString();
    }
}
