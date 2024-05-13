using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMedCapsuleSlot : UISlot
{
    private CharacterInfo _characterInfo;
    private UIDragCharacterContainer _characterContainer;

    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private SpendButton _healthButton;
    [SerializeField] private SpendButton _traumaButton;
    [SerializeField] private SpendButton _mutilationButton;
    [SerializeField] private GameObject _patient;

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
            CheckButtons();
            _buttonPanel.SetActive(true);

            if (_characterContainer.OldParent.TryGetComponent(out UIMedCapsuleSlot slot))
            {
                slot.ButtonPanel.SetActive(false);
                slot.Character = null;
            }
            var currentIndex = ButtonPanel.transform.parent.GetSiblingIndex();
            ButtonPanel.transform.parent.SetSiblingIndex(currentIndex + 1);
        }
    }

    private void CheckButtons()
    {
        Character = _characterContainer.Character;
        _healthButton.gameObject.SetActive(Character.Health < Character.EntityChars.MaxHealth);
        _healthButton.CheckEnabled();
        _traumaButton.gameObject.SetActive(Character.Conditions.HasTrauma);
        _traumaButton.CheckEnabled();
        _mutilationButton.gameObject.SetActive(Character.Conditions.Mutilations.Count > 0);
        _mutilationButton.CheckEnabled();
    }

    public void SetMedicalState(int state)
    {
        _characterInfo.MedicalState = (MedicalState)state;

        _buttonPanel.SetActive(false);

        _characterContainer.gameObject.SetActive(false);
        _patient.SetActive(true);
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

