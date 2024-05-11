using UnityEngine;

public static class EntityFactory
{
    public static EntityContainer CreateEntity(EntityInfo entityInfo, GameObject parent)
    {
        var entity = GameObject.Instantiate(Global.CommonPrefabs.EntityPrefab, parent.transform).GetComponent<EntityContainer>();
        entity.transform.localPosition = Vector3.zero;
        entity.transform.localScale = Vector3.one;
        entity.EntityInfo = entityInfo;
        return entity;
    }


    public static CharacterInfo CreateRandomCharacter()
    {
        var index = new System.Random().Next(0, Global.generableCharacterClasses.Count);
        var character = Global.generableCharacterClasses[index].CreateInstance() as CharacterInfo;

        return character;
    }

    public static CharacterInfo CreateCharacter(CharsTemplate template)
    {
        return template.CreateInstance() as CharacterInfo;
    }
}

