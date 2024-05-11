using UnityEngine;

public class SpendButton : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private int _medicine;
    [SerializeField] private int _metal;
    [SerializeField] private int _electronics;

    [SerializeField] private ResourcePanel _resourcePanel;

    public Resource Resource
    {
        get => new Resource() { Energy = _energy, Medicine = _medicine, Metal = _metal, Electronics = _electronics }; 
    }

    private void OnEnable()
    {
        _resourcePanel.Init(Resource);
    }
}
