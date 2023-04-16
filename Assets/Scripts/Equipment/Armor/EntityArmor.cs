using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum ArmorType
{
    BodyArmorLigth,//защищает от пистолетной пули, осколков и ножевого удара;
    BodyArmorHeavy,//такие бронежилеты рассчитаны на применение в войсках и способны защитить своего носителя даже от пули из автомата;
    SapperBodyArmor,//специализированная защита для бойцов соответствующего подразделения;
    HiddenBodyArmor//такая защита не видна не только под верхней одеждой, но даже и под легкой футболкой, ориентирована на сотрудников
                   //охранных подразделений. При этом такой бронежилет является оптимальной защитой от любого вида ножей и пуль из пистолета.
}

public abstract class EntityArmor : Equipment
{
   public ArmorType Type { get; set; }
}

