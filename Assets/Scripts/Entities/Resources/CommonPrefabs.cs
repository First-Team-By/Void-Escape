using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Resources
{
    public class CommonPrefabs : MonoBehaviour
    {
        [SerializeField] private GameObject _itemContainer;
        public GameObject ItemContainer => _itemContainer;
    }
}
