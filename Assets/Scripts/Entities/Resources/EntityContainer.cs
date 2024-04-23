using UnityEngine;

public class EntityContainer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public EntityInfo EntityInfo
    {
        get => _entityInfo;
        set => _entityInfo = value;
    }

    private EntityInfo _entityInfo;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = EntityInfo.FullFaceSprite;
    }

    public void RefreshImage()
    {
        if (_spriteRenderer == null)
            return;

        if(EntityInfo.OnDeathDoor) 
        {
            _spriteRenderer.sprite = EntityInfo.DeathDoorSprite;
        }
        else
        {
            _spriteRenderer.sprite = EntityInfo.FullFaceSprite;

        }
    }
}
