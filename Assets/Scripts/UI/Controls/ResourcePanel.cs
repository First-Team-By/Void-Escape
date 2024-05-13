using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    private int NumResources = 0;
    private bool _initialized = false;

    public void Init(Resource resource)
    {
        if (_initialized)
        {
            return;
        }
        _initialized = true;
        if (resource.Energy > 0)
        {
            var energyTag = Instantiate(Global.CommonPrefabs.UITag, this.gameObject.transform).GetComponent<UITag>();
            energyTag.Init(Global.ResourceImages["energy"], resource.Energy.ToString());
            NumResources++;
        }

        if (resource.Medicine > 0)
        {
            var medicineTag = Instantiate(Global.CommonPrefabs.UITag, this.gameObject.transform).GetComponent<UITag>();
            medicineTag.Init(Global.ResourceImages["medicine"], resource.Medicine.ToString());
            NumResources++;
        }

        if (resource.Metal > 0)
        {
            var metalTag = Instantiate(Global.CommonPrefabs.UITag, this.gameObject.transform).GetComponent<UITag>();
            metalTag.Init(Global.ResourceImages["metal"], resource.Metal.ToString());
            NumResources++;
        }

        if (resource.Electronics > 0)
        {
            var energyTag = Instantiate(Global.CommonPrefabs.UITag, this.gameObject.transform).GetComponent<UITag>();
            energyTag.Init(Global.ResourceImages["electronics"], resource.Electronics.ToString());
            NumResources++;
        }

        if (NumResources < 3)
        {
            var sizeDelta = gameObject.transform.GetComponent<RectTransform>().sizeDelta;
            sizeDelta.y = sizeDelta.y - 20;
            gameObject.transform.GetComponent<RectTransform>().sizeDelta = sizeDelta;
            if (_parent != null)
            {
                sizeDelta = _parent.transform.GetComponent<RectTransform>().sizeDelta;
                sizeDelta.y = sizeDelta.y - 20;
                _parent.transform.GetComponent<RectTransform>().sizeDelta = sizeDelta;
            }
        }
    }
}
