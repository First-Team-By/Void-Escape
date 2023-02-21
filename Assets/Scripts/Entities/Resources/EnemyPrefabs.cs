using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject commonMutant;
    [SerializeField] private GameObject middleMutant;
    [SerializeField] private GameObject megaMutant;

    public GameObject CommonMutant => commonMutant;
    public GameObject MiddleMutant => middleMutant;
    public GameObject MegaMutant => megaMutant;

    public List<GameObject> EnemyPrefabsList => new List<GameObject>()
    {
        CommonMutant,
        MiddleMutant,
        MegaMutant
    };
}
