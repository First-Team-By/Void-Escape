using UnityEngine;

public class EntityContainer : MonoBehaviour
{
    public EntityInfo EntityInfo
    {
        get => _entityInfo;
        set => _entityInfo = value;
    }

    private EntityInfo _entityInfo;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = EntityInfo.FullFaceSprite;
    }
}
