using UnityEngine;

namespace Assets.Scripts.Entities.Resources
{
    public class CommonPrefabs : MonoBehaviour
    {
        [SerializeField] private GameObject _itemContainer;
        [SerializeField] private GameObject _entityPrefab;
        [SerializeField] private GameObject _uiTag;
        [SerializeField] private GameObject _storagePositionContainer;
        
        public GameObject ItemContainer => _itemContainer;
        public GameObject EntityPrefab => _entityPrefab;
        public GameObject UITag => _uiTag;
        public GameObject StoragePositionContainer => _storagePositionContainer;
    }
}
