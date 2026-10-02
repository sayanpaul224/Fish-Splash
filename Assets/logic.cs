using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logic : MonoBehaviour
{
    public int score;
    public Text textscore;
    public GameObject gameoverscreen;

    public int triggergap = 10;
    public float speedincrease = 4f;

    private int firsttrigger = 5;

    public AudioSource bgm;
    public AudioSource game_over;

    private bool gameOverTriggered = false;

    [ContextMenu("Increase Score")]
    public void addscore(int scoretoadd)
    {
        score += scoretoadd;
        textscore.text = score.ToString();

        if (score >= firsttrigger)
        {
            movepillar.movespeed = 5f + (score * 0.15f);
            firsttrigger += triggergap;

            Debug.Log("Score: " + score + " | Speed: " + movepillar.movespeed);
        }
    }
    public void restartgame()
    {
        movepillar.movespeed = 5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    public void gameover()
    {
        if (gameOverTriggered) return;

        gameOverTriggered = true;

        gameoverscreen.SetActive(true);
        bgm.Stop();
        game_over.Play();
    }
}
