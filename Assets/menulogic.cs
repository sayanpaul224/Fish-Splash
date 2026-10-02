using UnityEngine;
using UnityEngine.UI;

public class menulogic : MonoBehaviour
{
    public Button playButton;
    public Button soundButton;
    public Button exitButton;

    public Text soundButtonText;

    void Start()
    {
        Time.timeScale = 1f;

        // 🔥 Assign listeners via code (PERMANENT FIX)
        playButton.onClick.AddListener(PlayGame);
        soundButton.onClick.AddListener(ToggleSound);
        exitButton.onClick.AddListener(ExitGame);

        UpdateSoundText();
    }

    void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Game");
    }

    public void ToggleSound()
    {
        if (Soundmanager.instance != null)
        {
            Soundmanager.instance.ToggleSound();
        }

        UpdateSoundText();
    }

    void UpdateSoundText()
    {
        if (soundButtonText != null)
        {
            soundButtonText.text = Soundmanager.isMuted ? "UNMUTE" : "MUTE";
        }
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}