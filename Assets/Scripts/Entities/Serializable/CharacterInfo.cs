using System.Collections.Generic;
using System.Linq;


public abstract class CharacterInfo : EntityInfo
{
    protected float _currentHealth;
    public EntityWeapon Weapon { set; get; }
    public EntityDevice Device { set; get; }
    public EntityArmor Armor { set; get; }

    public override EntityResistances Resistances
    {
        get
        {
            return NaturalResistance + Armor.Resistances;
        }
    }


    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    //public GameObject CharacterPrefab
    //{
    //    get => _characterPrefab;
    //    set => _characterPrefab = value;
    //}

    public abstract List<CharacterCommand> NativeCommands { get; }

    public override List<EntityCommand> Commands
    {
        get
        {
            return NativeCommands.Where(x => x.IsAvaliable(this)).Select(x => x as EntityCommand).ToList();
        }
    }

    public int Id { get; set; }

    public CharacterInfo() : base()
    {
        FullName = NameGenerator.CreateFullName();
    }
}

