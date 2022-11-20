using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMainMenu : MonoBehaviour
{
    public Button startButton;
    public Button creditButton;
    public Button exitButton;
    public Button closeButton;
    public string levelSceneName;
    public GameObject creditUI;

    private void Awake()
    {
        startButton.onClick.AddListener(() => StartButton(levelSceneName));
        creditButton.onClick.AddListener(() => CreditButton());
        exitButton.onClick.AddListener(() => ExitButton());
        closeButton.onClick.AddListener(() => CloseButton());
    }
    private void StartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void CreditButton()
    {
        creditUI.SetActive(true);
    }
    private void ExitButton()
    {
        Application.Quit();
    }
    private void CloseButton()
    {
        creditUI.SetActive(false);
    }


}
