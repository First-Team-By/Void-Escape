using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("���� �������� ����� ����")]
    public GameObject newGameWindow;

    [Header("���� �����")]
    public GameObject optionsWindow;

    [Header("�������� ����� ��� ��������")]
    [SerializeField] private string _sceneNumber;

    void Start()
    {
        // ����������� ����� ...
    }

    public void ButtonNewGame()
    {
        newGameWindow.SetActive(true);

        optionsWindow.SetActive(false);
    }

    public void ButtonNewScene()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
