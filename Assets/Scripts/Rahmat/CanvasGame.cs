using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CanvasGame : MonoBehaviour
{
    public GameObject pauseUI;
    public Button pauseButton;
    public Button resumeButton;
    public Button backToMenuButton;
    public TextMeshProUGUI healthUI;
    public DummyPlayerScript player;
    private void Awake()
    {
        pauseButton.onClick.AddListener(() => PauseButton());
        backToMenuButton.onClick.AddListener(() => BackToMenuButton());
        resumeButton.onClick.AddListener(() => Resume());
        player = FindObjectOfType<DummyPlayerScript>();
    }
    private void Start()
    {
        pauseUI.SetActive(false);
    }
    private void Update()
    {
        healthUI.text = player.health.ToString();
    }

    private void PauseButton()
    {
        if (!pauseUI.activeSelf)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else if (pauseUI.activeSelf)
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }
    private void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }
    private void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
