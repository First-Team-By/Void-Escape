using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => Global.SpendResources(Resource));
        Global.ResourcesCanged += CheckEnabled;
    }

    private void OnEnable()
    {
        _resourcePanel.Init(Resource);        
    }

    public void CheckEnabled()
    {
        GetComponent<Button>().interactable = Global.Storage.Resources.IsEnought(Resource);
    }

    
}
