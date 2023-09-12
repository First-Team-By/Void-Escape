using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HibernationCapsule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EntityCardScript _entityCardScript;
    [SerializeField] private HibernationChamber _hibernaiteChamber;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _topAnimator;
    [SerializeField] private UIPopUPWindow _uIPopUPWindow;
    private HibernationCapsuleInfo _capsuleInfo;

    public HibernationCapsuleInfo CapsuleInfo
    {
        get { return _capsuleInfo; }
        set { _capsuleInfo = value; }
    }

    public void Extract()
    {
        Debug.Log("extracted");
        if  (_capsuleInfo.Status == CapsuleStatus.Empty || _capsuleInfo.Status == CapsuleStatus.Freezed)
        {
            return;
        }


        var lastCharacter = Global.allCharacters.CharacterInfos.OrderBy(x => x.Id).LastOrDefault();
        if (lastCharacter != null)
        {
            _capsuleInfo.Character.Id = lastCharacter.Id + 1;
        }
        else
        {
            _capsuleInfo.Character.Id = 0;
        }
        Global.allCharacters.CharacterInfos.Add(_capsuleInfo.Character);
        StartCoroutine(OnEnableUIPopUpWinCor($"{_capsuleInfo.Character.FullName} ({_capsuleInfo.Character.ClassName})"));
        _capsuleInfo.Character = null;
        _capsuleInfo.Status = CapsuleStatus.Empty;
        _hibernaiteChamber.SaveToGlobal();
        _entityCardScript.gameObject.SetActive(false);
        _topAnimator.SetTrigger("Extract");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _entityCardScript.FillInfo(_capsuleInfo.Character);
        _entityCardScript.RefreshEquipments();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _entityCardScript.FillInfo(null);
    }

    public void CheckStatus()
    {
        if (_capsuleInfo.Status == CapsuleStatus.UnFreezed)
        {
            _capsuleInfo.Character = CharacterFactory.CreateRandomCharacter();
            _capsuleInfo.Status = CapsuleStatus.Opened;
            _hibernaiteChamber.SaveToGlobal();

            _animator.SetTrigger("Open");
        }
        else if (_capsuleInfo.Status == CapsuleStatus.Opened || _capsuleInfo.Status == CapsuleStatus.Empty)
        {
            _animator.SetTrigger("Opened");
        }else if (_capsuleInfo.Status == CapsuleStatus.Freezed)
        {
            _animator.SetTrigger("Closed");
        }

        if (_capsuleInfo.Status == CapsuleStatus.Empty)
        {
            _topAnimator.SetBool("Extracted", true);
        }
    }

    public void Freeze()
    {
        if (_capsuleInfo.Status == CapsuleStatus.Opened)
        {
            _capsuleInfo.Character = null;
            _capsuleInfo.Status = CapsuleStatus.Freezed;
            _hibernaiteChamber.SaveToGlobal();
            _entityCardScript.FillInfo(_capsuleInfo.Character);

            _animator.SetTrigger("Close");
        }
    }

    private IEnumerator OnEnableUIPopUpWinCor(string identifier)
    {
        yield return new WaitForSeconds(1.6f);

        _uIPopUPWindow.OnEnableUIPopUpWindow(identifier);
    }
}

