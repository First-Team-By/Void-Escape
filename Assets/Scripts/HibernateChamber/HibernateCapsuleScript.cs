using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HibernateCapsuleScript : MonoBehaviour, IPointerEnterHandler
{
    public HibernateCapsule capsuleInfo;

    [SerializeField] private EntityCardScript _entityCardScript;

    [SerializeField] private HibernaiteChamber _hibernaiteChamber;


    public void Extract()
    {
        if  (capsuleInfo.Status == CapsuleStatus.Empty)
        {
            return;
        }

        Global.allCharacters.CharacterInfos.Add(CharacterFactory.CreateCharacterInfo(capsuleInfo.Character));
        capsuleInfo.Character = null;
        capsuleInfo.Status = CapsuleStatus.Empty;
        _hibernaiteChamber.SaveToGlobal();
        _entityCardScript.FillInfo(capsuleInfo.Character);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (capsuleInfo.Character != null)
        //{
        //    _characterName.text = capsuleInfo.Character.ClassName;


        //}
        //else
        //{
        //    _characterName.text = "Пусто !";
        //}

        _entityCardScript.FillInfo(capsuleInfo.Character);
    }

    public void Open()
    {
        if (capsuleInfo.Status == CapsuleStatus.JustOpened)
        {
            var index = new System.Random().Next(0, Global.availableClasses.Count);
            capsuleInfo.Character = GameObject.Instantiate(Global.availableClasses[index]).GetComponent<Character>();
            capsuleInfo.Status = CapsuleStatus.Opened;
            _hibernaiteChamber.SaveToGlobal();
        }

    }
}

