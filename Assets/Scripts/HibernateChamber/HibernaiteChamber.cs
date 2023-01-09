using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibernaiteChamber : MonoBehaviour
{
    [SerializeField] private HibernateCapsuleScript[] capsules;

    private void Awake()
    {
        LoadeFromGlobal();
    }

    private void OnEnable()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            capsules[i].Open();
        }
    }

    public void SaveToGlobal()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            Global.capsules[i] = capsules[i].capsuleInfo;
        }
    }

    public void LoadeFromGlobal()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            capsules[i].capsuleInfo = Global.capsules[i];
        }
    }
}
