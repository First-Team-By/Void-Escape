using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CharacterGroup
{
    public List<CharacterInfo> CharacterInfos { get; set; }

    public CharacterGroup()
    {
        CharacterInfos = new List<CharacterInfo>()
        {
            new CharacterInfo() { CharacterPrefab = Global.CharacterPrefabs.Medic, Conditions = new EntityConditions(), CurrentHealth = 10, Id = 1},
            new CharacterInfo() { CharacterPrefab = Global.CharacterPrefabs.Officer, Conditions = new EntityConditions(), CurrentHealth = 10, Id = 2}
        };
    }
}

