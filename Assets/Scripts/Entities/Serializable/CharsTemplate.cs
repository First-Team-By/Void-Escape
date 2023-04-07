using System;
using System.Linq;
using System.Net.Http.Headers;

public class CharsTemplate
{
    public EntityCharacteristics EntityChars { get; private set; }
    public Type EntityType { get; private set; }

    

    public CharsTemplate(EntityCharacteristics entityChars, Type type)
    {
        EntityChars = entityChars;
        EntityType = type;
    }

    public CharsTemplate()
    {
        
    }

    public static Type GetEntityClass(EntityClass entityClass)
    {
        foreach (var entityTemplate in Global.AllEntityTemplates)
        {
            if (entityTemplate.EntityChars.EntityClass == entityClass)
            {
                return entityTemplate.EntityType;
            }
        }
        return null;
    }

    public static EntityCharacteristics GetCharacteristics(EntityClass entityClass)
    {
        return Global.AllEntityTemplates.FirstOrDefault(x => x.EntityChars.EntityClass == entityClass).EntityChars;
    }

    public Type GetEntityClass()
    {
        return GetEntityClass(EntityChars.EntityClass);
    }

    public EntityInfo CreateInstance()
    {
        return (EntityInfo)Activator.CreateInstance(GetEntityClass());
    }
}


