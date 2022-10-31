using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Окно создания новой игры")]
    public GameObject newGameWindow;

    [Header("Окно опций")]
    public GameObject optionsWindow;

    [Header("Название сцены для загрузки")]
    [SerializeField] private string _sceneNumber;

    void Start()
    {
        // Понадобится позже ...
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
