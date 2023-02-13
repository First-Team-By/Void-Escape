using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyInfo
{
    [SerializeField] private GameObject _enemyPrefab;
    public GameObject EnemyPrefab
    {
        get => _enemyPrefab;
        set => _enemyPrefab = value;
    }
}
