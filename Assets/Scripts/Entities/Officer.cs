using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Officer : Character
{
    public override List<CharacterCommand> NativeCommands => new List<CharacterCommand>()
    {
        new DoubleTap(),
        new SingleFire()
    };

    protected override void Init()
    {
        Weapon = new Pistol();

        Prefab = Global.CharacterPrefabs.Officer;
    }
}