using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum ArmorType
{
    Light, //защищает от пистолетной пули, осколков и ножевого удара;

    Heavy,  //такие бронежилеты рассчитаны на применение в войсках и способны защитить своего носителя даже от пули из автомата;

    Sapper,  //специализированная защита для бойцов соответствующего подразделения;
    
    Hidden  //такая защита не видна не только под верхней одеждой, но даже и под легкой футболкой, ориентирована на сотрудников
                     //охранных подразделений. При этом такой бронежилет является оптимальной защитой от любого вида ножей и пуль из пистолета.
}

public abstract class EntityArmor : Equipment
{
    protected EntityResistances _resistances;

    public EntityArmor() 
    {
        _resistances = new EntityResistances();
    }

    public ArmorType Type { get; set; }

    public EntityResistances Resistances { get => _resistances; }
}

