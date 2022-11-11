using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject officer;
    [SerializeField] private GameObject medic;

    public GameObject Officer => officer;
    public GameObject Medic => medic;
}
