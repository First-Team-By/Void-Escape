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
			
		};
	}
	
	public void AddCharacter(CharacterInfo character)
	{
		CharacterInfos.Add(character);
		character.OnAddedToTeam();
	}

    internal object Where(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}

