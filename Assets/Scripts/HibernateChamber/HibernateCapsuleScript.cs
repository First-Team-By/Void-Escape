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

    [SerializeField] private Animator _animator;

    [SerializeField] private Animator _topAnimator;

    public void Extract()
    {
        if  (capsuleInfo.Status == CapsuleStatus.Empty || capsuleInfo.Status == CapsuleStatus.Freezed)
        {
            return;
        }

        Global.allCharacters.CharacterInfos.Add(CharacterFactory.CreateCharacterInfo(capsuleInfo.Character));
        capsuleInfo.Character = null;
        capsuleInfo.Status = CapsuleStatus.Empty;
        _hibernaiteChamber.SaveToGlobal();
        _entityCardScript.FillInfo(capsuleInfo.Character);
        _topAnimator.SetTrigger("Extract");
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

    public void CheckStatus()
    {
        if (capsuleInfo.Status == CapsuleStatus.UnFreezed)
        {
            var index = new System.Random().Next(0, Global.availableClasses.Count);
            capsuleInfo.Character = GameObject.Instantiate(Global.availableClasses[index]).GetComponent<Character>();
            capsuleInfo.Status = CapsuleStatus.Opened;
            _hibernaiteChamber.SaveToGlobal();

            _animator.SetTrigger("Open");
        }
        else if (capsuleInfo.Status == CapsuleStatus.Opened || capsuleInfo.Status == CapsuleStatus.Empty)
        {
            _animator.SetTrigger("Opened");
        }else if (capsuleInfo.Status == CapsuleStatus.Freezed)
        {
            _animator.SetTrigger("Closed");
        }

        if (capsuleInfo.Status == CapsuleStatus.Empty)
        {
            _topAnimator.SetBool("Extracted", true);
        }
    }

    public void Freeze()
    {
        if (capsuleInfo.Status == CapsuleStatus.Opened)
        {
            capsuleInfo.Character = null;
            capsuleInfo.Status = CapsuleStatus.Freezed;
            _hibernaiteChamber.SaveToGlobal();
            _entityCardScript.FillInfo(capsuleInfo.Character);

            _animator.SetTrigger("Close");
        }
    }
}

