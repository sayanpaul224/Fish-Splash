using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager instance;
    public static bool isMuted = false;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        isMuted = PlayerPrefs.GetInt("Muted") == 1;
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        AudioListener.volume = isMuted ? 0f : 1f;

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    void OnEnable()
    {
        Time.timeScale = 1f;
    }
}