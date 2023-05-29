public abstract class CharacterCommand : EntityCommand
{
    protected float damage;
    public abstract bool IsAvaliable(EntityInfo entity);
}
