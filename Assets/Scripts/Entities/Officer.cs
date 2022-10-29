using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Officer : Character
{
    private void Awake()
    {
        Weapon = new Pistol();
    }

}