﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterGroup
{
    public List<CurrentCharacterInfo> CurrentCharacterInfos { get; set; }

    public CharacterGroup()
    {
        CurrentCharacterInfos = new List<CurrentCharacterInfo>();
    }
}
