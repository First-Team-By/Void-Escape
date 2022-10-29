using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject CharacterPositions;
    [SerializeField] private GameObject EnemyPositions;

    private Dictionary<Character, int> characters;
    private Dictionary<Character, int> enemies;
    public void Init(Dictionary<Character, int> characters, Dictionary<Character, int> enemies)
    {
        this.characters = characters;
        this.enemies = enemies;

        Transform[] charactersPositions = CharacterPositions.gameObject.GetComponentsInChildren<Transform>();
        Transform[] enemiesPositions = EnemyPositions.gameObject.GetComponentsInChildren<Transform>();
    }

    public void EntitySelect(EntityBase entity)
    {

    }

    public void SwapEntitiesPosition(EntityBase entity1, EntityBase entity2)
    {

    }

    private void SetEntities(GameObject position, Dictionary<EntityBase, int> entities)
    {
        Transform[] positions = position.GetComponentsInChildren<Transform>();

        for (int i = 0; i < entities.Count; i++)
        {
            
        }
    }
}
