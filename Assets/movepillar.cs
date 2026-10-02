using UnityEngine;

public class movepillar : MonoBehaviour
{
    public static float movespeed = 5f;

    public float deadzone = -12f;

    private static float timer = 0f;

    void Update()
    {
        // Move pillar
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        // Only ONE timer runs (shared across all pillars)
        timer += Time.deltaTime;

        // Destroy off-screen
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
}