using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CurrentCharacterGroup
{
    public List<CharacterInfo> CurrentCharacterInfos { get; set; }

    public CurrentCharacterGroup()
    {
        CurrentCharacterInfos = new List<CharacterInfo>();
    }
}
