using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Medic : Character
{
    public override List<CharacterCommand> NativeCommands => new List<CharacterCommand>()
    {
        new HealOne(),
        new Coagulator(),
        new DeepCut()
    };

    protected override void Init()
    {
        Prefab = Global.CharacterPrefabs.Medic;

        //Weapon = new Scalpel();
    }
}
