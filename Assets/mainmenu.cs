using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync("Main Game");
    }
}
