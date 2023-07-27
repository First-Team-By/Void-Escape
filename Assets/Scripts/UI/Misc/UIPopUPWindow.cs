using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUPWindow : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Text _uiPopUpText;

    [SerializeField] private EntityCardScript _entityCardScript;

    public void OnEnableUIPopUpWindow(string identifier)
    {
        gameObject.SetActive(true);

        _uiPopUpText.text = $"{identifier} ������������� � �������! �������� ��������� ({CharacterInfo.RarityNames[1]})";
    }

    public void CloseWindow()
    {
        StartCoroutine(CoroutineCloseWindow());
    }
    private IEnumerator CoroutineCloseWindow()
    {
        _animator.SetTrigger("hide");

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
