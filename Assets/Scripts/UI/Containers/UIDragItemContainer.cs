using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragItemContainer : UIDragContainer
{
  //  public int CharacterId { get; set; }

    public Item Item => (Item)_businessObject;

    public override void Initialize()
    {
        return;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ToggleImagePanels(true);

        Debug.Log("On begin drag");


        if(transform.parent.parent != null 
            && transform.parent.parent.TryGetComponent<UIStoragePositionContainer>(out UIStoragePositionContainer storagePositionParent))
        {
            storagePositionParent.StoragePosition.RemoveItem();
            if (storagePositionParent.StoragePosition.Amount > 0 || storagePositionParent.StoragePosition.IsInfinite)
                storagePositionParent.CreateItemContainer(Item);
            else 
            {
                Destroy(storagePositionParent.gameObject);
            }
            OldParent = storagePositionParent.transform.parent;
        }
        else 
        { 
            OldParent = transform.parent; 
        }       

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = false;

        transform.SetParent(_rootPanel);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        Debug.Log("OnEnDrag");

        transform.localPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;

        _canvasGroup.blocksRaycasts = true;
    }

    public override void ReturnToOldParent()
    {
        if (OldParent.TryGetComponent<UIStorgePositionListController>(out UIStorgePositionListController storagePositionListControllerParent))
        {
            if (!Item.IsInfinite)
            {
                storagePositionListControllerParent.DropItemContainer(Item);
                //var existingStoragePositionContainer = storagePositionListControllerParent.GetStoragePositionContainer(Item);
                //if (existingStoragePositionContainer != null)
                //{
                //    storagePositionListControllerParent.AddItem(Item);
                //}
                //else
                //{
                //    storagePositionListControllerParent.AddNewItem(Item);
                //}
            }
            Destroy(gameObject);
        }
        else
        {
            base.ReturnToOldParent();
        }
    }
}
