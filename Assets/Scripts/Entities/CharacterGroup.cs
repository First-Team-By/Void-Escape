using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterGroup
{
    public List<Character> CharacterList { get; set; }
    public CharacterGroup(List<Character> characters)
    {
        CharacterList = characters;
    }

    public CharacterGroup()
    {
        
    }
}
