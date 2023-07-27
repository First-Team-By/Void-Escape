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

public class HibernateCapsuleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public HibernateCapsule capsuleInfo;

    [SerializeField] private EntityCardScript _entityCardScript;

    [SerializeField] private HibernaiteChamber _hibernaiteChamber;

    [SerializeField] private Animator _animator;

    [SerializeField] private Animator _topAnimator;

    [SerializeField] private UIPopUPWindow _uIPopUPWindow;

    public HibernateCapsule CapsuleInfo
    {
        get { return capsuleInfo; }
        set { capsuleInfo = value; }
    }

    public void Extract()
    {
        Debug.Log("extracted");
        if  (capsuleInfo.Status == CapsuleStatus.Empty || capsuleInfo.Status == CapsuleStatus.Freezed)
        {
            return;
        }

        Global.allCharacters.CharacterInfos.Add(capsuleInfo.Character);
        StartCoroutine(OnEnableUIPopUpWinCor($"{capsuleInfo.Character.FullName} ({capsuleInfo.Character.ClassName})"));
        capsuleInfo.Character = null;
        capsuleInfo.Status = CapsuleStatus.Empty;
        _hibernaiteChamber.SaveToGlobal();
        _entityCardScript.gameObject.SetActive(false);
        _topAnimator.SetTrigger("Extract");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _entityCardScript.FillInfo(capsuleInfo.Character);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _entityCardScript.FillInfo(null);
    }

    public void CheckStatus()
    {
        if (capsuleInfo.Status == CapsuleStatus.UnFreezed)
        {
            
            capsuleInfo.Character = CharacterFactory.CreateRandomCharacter();
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

    private IEnumerator OnEnableUIPopUpWinCor(string identifier)
    {
        yield return new WaitForSeconds(1.6f);

        _uIPopUPWindow.OnEnableUIPopUpWindow(identifier);
    }
}

