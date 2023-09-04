using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMedCapsuleSlot : UISlot
{
    //[SerializeField] private Transform _medicalCharacterPanel;
    //[SerializeField] private GameObject _medCapsuleSlot;

    private CharacterInfo _characterInfo;
    private UIDragCharacterContainer _characterContainer;

    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _traumaButton;
    [SerializeField] private Button _mutilationButton;

    public GameObject ButtonPanel => _buttonPanel;
    public CharacterInfo Character
    {
        get => _characterInfo;
        set
        {
            _characterInfo = value; 
            if (value == null)
            {
                _buttonPanel.SetActive(false);
            }
        }
    } 

    public override Type ContainerType => typeof(UIDragCharacterContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        if (Character != null)
        {
            container.ReturnToOldParent();
            return;
        }
        
        _characterContainer = container as UIDragCharacterContainer;
        
        if (_characterContainer != null)
        {
            Character = _characterContainer.Character;
            _healthButton.gameObject.SetActive(Character.Health < Character.EntityChars.MaxHealth);
            _traumaButton.gameObject.SetActive(Character.Conditions.HasTrauma);
            _mutilationButton.gameObject.SetActive(Character.Conditions.Mutilations.Count > 0);
            _buttonPanel.SetActive(true);

            if (_characterContainer.OldParent.TryGetComponent<UIMedCapsuleSlot>(out UIMedCapsuleSlot slot))
            {
                slot.ButtonPanel.SetActive(false);
                slot.Character = null;
            }
        }
    }

    public void SetMedicalState(int state)
    {
        _characterInfo.MedicalState = (MedicalState)state;

        _buttonPanel.SetActive(false);

        _characterContainer.enabled = false;
    }

    private void OnDisable()
    {
        if (Character != null && Character.MedicalState == MedicalState.Idle)
        {
            Destroy(_characterContainer.gameObject);
            Character = null;
        }
    }
}

