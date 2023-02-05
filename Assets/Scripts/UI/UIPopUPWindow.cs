using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUPWindow : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Text _uiPopUpText;

    [SerializeField] private EntityCardScript _entityCardScript;

    private string _className;

    public void OnEnableUIPopUpWindow()
    {
        gameObject.SetActive(true);

        _className = _entityCardScript.EntityType.text;

        _uiPopUpText.text = $"{_className} присоединился к команде!";
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
