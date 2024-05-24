using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HibernationCapsule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EntityCardScript _entityCardScript;
    [SerializeField] private HibernationChamber _hibernaiteChamber;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _topAnimator;
    [SerializeField] private UIPopUPWindow _uIPopUPWindow;
    [SerializeField] private Button _plugButton;
    [SerializeField] private Button _repairButton;
    [SerializeField] private GameObject _hidePanel;
    [SerializeField] private GameObject _brokenImage;
  //  [SerializeField] private UIResourceWindow _resourceWindow;
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

        var lastCharacter = Global.AllCharacters.CharacterInfos.OrderBy(x => x.Id).LastOrDefault();
        if (lastCharacter != null)
        {
            _capsuleInfo.Character.Id = lastCharacter.Id + 1;
        }
        else
        {
            _capsuleInfo.Character.Id = 0;
        }
        Global.AllCharacters.AddCharacter(_capsuleInfo.Character);
        StartCoroutine(OnEnableUIPopUpWinCor($"{_capsuleInfo.Character.FullName} ({_capsuleInfo.Character.ClassName})"));
        _capsuleInfo.Character = null;
        _capsuleInfo.Status = CapsuleStatus.Empty;
        _hibernaiteChamber.SaveToGlobal();
        _entityCardScript.gameObject.SetActive(false);
        _topAnimator.SetTrigger("Extract");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_capsuleInfo.Status == CapsuleStatus.UnPlugged || _capsuleInfo.Status == CapsuleStatus.Broken)
            _entityCardScript.FillInfo(null);
        _entityCardScript.FillInfo(_capsuleInfo.Character);
        _entityCardScript.RefreshEquipments();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _entityCardScript.FillInfo(null);
    }

    public void CheckStatus()
    {
        _plugButton.gameObject.SetActive(_capsuleInfo.Status == CapsuleStatus.UnPlugged);
        _repairButton.gameObject.SetActive(_capsuleInfo.Status == CapsuleStatus.Broken);
        _brokenImage.SetActive(_capsuleInfo.Status == CapsuleStatus.Broken);

        _hidePanel.SetActive(_capsuleInfo.Status == CapsuleStatus.UnPlugged || _capsuleInfo.Status == CapsuleStatus.Broken);


        if (_capsuleInfo.Status == CapsuleStatus.UnPlugged || _capsuleInfo.Status == CapsuleStatus.Broken)
            return;

        if (_capsuleInfo.Status == CapsuleStatus.UnFreezed)
        {
            _capsuleInfo.Character = EntityFactory.CreateRandomCharacter();
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

    public void ClickPlugButton()
    {
        _capsuleInfo.Status = CapsuleStatus.Freezed;
        CheckStatus();
    }
    public void ClickRepairButton()
    {
        _capsuleInfo.Status = CapsuleStatus.UnPlugged;
        CheckStatus();
    }
}

