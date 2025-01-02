using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lateralSpeed = 4f;
    public float jumpHeight = 3f;
    public float speedIncrement = 1f; // Amount to increase speed
    public float interval = 10f; // Time in seconds between speed increases
    public static bool canMove = false;
    public bool isJumping = false;

    private bool comingDown = false;
    private Animator animator;

    void Start()
    {

          animator = this.GetComponentInChildren<Animator>();
        // Start the coroutine to increase speed every `interval` seconds
        StartCoroutine(IncreaseSpeedOverTime());

    }

    void Update()
    {
        MoveForward();
        if (canMove)
        {
            HandleLateralMovement();
            HandleJump();
        }
    }



    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void HandleLateralMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Combines A/D, Left/Right Arrow inputs.
        if (horizontalInput != 0)
        {
            float newXPosition = transform.position.x + horizontalInput * lateralSpeed * Time.deltaTime;
            newXPosition = Mathf.Clamp(newXPosition, LevelBoundary.leftSide, LevelBoundary.rightSide);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
    }

    private void HandleJump()
    {
        if (isJumping) return;

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
            comingDown = false;
            animator.Play("Jump");
            StartCoroutine(JumpSequence());
        }
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (true) // Repeat indefinitely
        {
            yield return new WaitForSeconds(interval);
            moveSpeed += speedIncrement;
            Debug.Log("New moveSpeed: " + moveSpeed);
        }
    }

    IEnumerator JumpSequence()
    {
        float jumpTime = 0.45f;

        // Jump up
        for (float t = 0; t < jumpTime; t += Time.deltaTime)
        {
            transform.Translate(Vector3.up * (jumpHeight * Time.deltaTime), Space.World);
            yield return null;
        }

        comingDown = true;

        // Come down
        for (float t = 0; t < jumpTime; t += Time.deltaTime)
        {
            transform.Translate(Vector3.down * (jumpHeight * Time.deltaTime), Space.World);
            yield return null;
        }

        isJumping = false;
        animator?.Play("Standard Run");
    }
}