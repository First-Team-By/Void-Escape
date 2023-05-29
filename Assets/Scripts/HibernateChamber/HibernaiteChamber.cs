using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibernaiteChamber : MonoBehaviour
{
    [SerializeField] private HibernateCapsuleScript[] capsules;

    [SerializeField] private EntityCardScript _card;

    private void Awake()
    {
        LoadFromGlobal();
    }

    private void OnEnable()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            capsules[i].CheckStatus();
        }

        _card.gameObject.SetActive(false);
    }

    public void SaveToGlobal()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            Global.capsules[i] = capsules[i].capsuleInfo;
        }
    }

    public void LoadFromGlobal()
    {
        for (int i = 0; i < capsules.Length; i++)
        {
            capsules[i].capsuleInfo = Global.capsules[i];
        }
    }
}
