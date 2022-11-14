using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Officer : Character
{
    public override List<CharacterCommand> NativeCommands => new List<CharacterCommand>()
    {
        new DoubleTap(),
        new SingleFire()
    };

    private void Awake()
    {
        Weapon = new Pistol();
        
        Prefab = Global.CharacterPrefabs.Officer;
    }

}