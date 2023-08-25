using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMedCapsuleSlot : MonoBehaviour, IDropHandler
{
    //[SerializeField] private Transform _medicalCharacterPanel;
    //[SerializeField] private GameObject _medCapsuleSlot;

    private CharacterInfo characterInfo;
    private UICharacterSlot _characterSlot;

    [SerializeField] private GameObject _cplPanel;
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _traumaButton;
    [SerializeField] private Button _mutilationButton;

    public GameObject ButtonPanel { get { return _cplPanel; } }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var dragChar = eventData.pointerDrag;

            _characterSlot = dragChar.GetComponent<UICharacterSlot>();


            //if (_medCapsuleSlot.transform.childCount == 2)
            //{
            //    _characterSlot.transform.SetParent(_medicalCharacterPanel.transform);
            //}


            if (_characterSlot != null)
            {
                characterInfo = _characterSlot.CharacterInfo;
                _healthButton.gameObject.SetActive(characterInfo.Health < characterInfo.EntityChars.MaxHealth);
                _traumaButton.gameObject.SetActive(characterInfo.Conditions.HasTrauma);
                _mutilationButton.gameObject.SetActive(characterInfo.Conditions.Mutilations.Count > 0);
            }

            dragChar.transform.SetParent(gameObject.transform);

            dragChar.GetComponent<RectTransform>().localPosition = Vector2.zero;

            _cplPanel.SetActive(true);

            Debug.Log("OnDrop");
        }
    }

    public void SetMedicalState(int state)
    {
        characterInfo.MedicalState = (MedicalState)state;

        _cplPanel.SetActive(false);

        _characterSlot.enabled = false;
    }

    public void SetMedTrauma(int state)

    {
        characterInfo.MedicalState = (MedicalState)state;

        _cplPanel.SetActive(false);

        _characterSlot.enabled = false;
    }

    public void SetMutilation(int state)
    {
        characterInfo.MedicalState = (MedicalState)state;

        _cplPanel.SetActive(false);

        _characterSlot.enabled = false;
    }

    public void SetImplant(int state)
    {
        characterInfo.MedicalState = (MedicalState)state;

        _cplPanel.SetActive(false);

        _characterSlot.enabled = false;
    }
}

