using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   // 👈 IMPORTANT

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    public Text pauseSoundText; // 👈 THIS is what you're missing

    private bool isPaused = false;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        UpdatePauseText(); // 👈 update when opened
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ToggleSound()
    {
        

        if (Soundmanager.instance != null)
        {
            Soundmanager.instance.ToggleSound();
        }

        UpdatePauseText();
    }

    void UpdatePauseText()
    {
        if (pauseSoundText != null)
        {
            pauseSoundText.text = Soundmanager.isMuted ? "UNMUTE" : "MUTE";
        }
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f; // ✅ VERY IMPORTANT

        // 🔥 Force UI reset
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);

        SceneManager.LoadScene("Menu");
    }
}