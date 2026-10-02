using UnityEngine;
using UnityEngine.InputSystem;

public class submraine : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapstrength = 8f;
    public float rotationSpeed = 1f;
    public logic logic;
    private bool isalive = true;
    private bool gameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // For intro animation
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float moveSpeed = 2f;

    private bool introFinished = false;
    void Start()
    {
        myrigidbody.gravityScale = 1.5f; // Low gravity at start
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();

        //Start position for intro animation
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();

        myrigidbody.gravityScale = 0;

        // Set starting position (top-left)
        startPosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 1.1f, 0));
        startPosition.z = 0;

        // Target position (middle-left-ish)
        targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.45f, 0.5f, 0));
        targetPosition.z = 0;

        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Intro animation
        if (!introFinished)
        {
            Vector2 direction = (targetPosition - transform.position).normalized;

            float distance = Vector2.Distance(transform.position, targetPosition);

            // speed goes from 5 → 4 as it approaches
            float currentSpeed = Mathf.Lerp(3f, 5f, distance);

            myrigidbody.linearVelocity = direction * currentSpeed;

            // Stop intro when close
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                introFinished = true;
            }

            return;
        }

        //Game starts on first space press
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isalive && introFinished)
        {
            if (!gameStarted)
            {
                gameStarted = true;
                myrigidbody.gravityScale = 3.1f;
            }

            myrigidbody.linearVelocity = Vector2.up * flapstrength;
        }

        // Get vertical velocity
        float velocityY = myrigidbody.linearVelocity.y;

        // Convert velocity to angle
        float angle = Mathf.Clamp(velocityY * 10f, -90f, 45f);

        // Smooth rotation
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            rotationSpeed * Time.deltaTime
        );

    Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Viewport goes from 0 to 1
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            logic.gameover();
            isalive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameover();
        isalive = false;
    }
}
