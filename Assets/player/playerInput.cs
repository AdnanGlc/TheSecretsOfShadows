using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour
{
    // References
    public CharacterController characterController;
    public Transform characterModel;
    public Transform cameraTransform;
    public Transform groundCheck;

    // Size potions variables
    public float defaultHeight = 1.8f;
    Vector3 defaultSize;

    // Player speed
    public float speed = 12.0f;

    // Gravity
    float gravity = -9.81f;
    Vector3 velocity;
    float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded = false;

    // Offset for groundCheck position
    public Vector3 groundCheckOffset = new Vector3(0f, -0.1f, 0f);

    // Animation
    float animationSpeed = 0.05f;

    // Scale reset variables
    public float scaleResetInterval = 30f;
    float lastScaleChangeTime = 0f;

    private void Start()
    {
        defaultSize = transform.localScale;
        lastScaleChangeTime = Time.time; // Initialize last scale change time
    }

    void Update()
    {
        CheckMovement();
        CheckPotion();
        CheckScaleResetTimer();
    }

    void CheckMovement()
    {
        // Player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = (float)Math.Sqrt(5.0f * 2f * gravity);
        // Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void CheckPotion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.localScale != defaultSize * 2.5f)
        {
            StartCoroutine(ScaleOverTime(defaultSize * 2.5f));
            lastScaleChangeTime = Time.time; // Update last scale change time
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.localScale != defaultSize * 0.2f)
        {
            StartCoroutine(ScaleOverTime(defaultSize * 0.2f));
            lastScaleChangeTime = Time.time; // Update last scale change time
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.localScale != defaultSize)
        {
            StartCoroutine(ScaleOverTime(defaultSize));
            lastScaleChangeTime = Time.time; // Update last scale change time
        }
    }
    void CheckScaleResetTimer()
    {
        // Check if 30 seconds have passed since the last scale change
        if (Time.time - lastScaleChangeTime > scaleResetInterval && transform.localScale != defaultSize)
        {
            StartCoroutine(ScaleOverTime(defaultSize));
            lastScaleChangeTime = Time.time; // Update last scale change time
        }
    }

    IEnumerator ScaleOverTime(Vector3 targetScale)
    {
        Vector3 scaleDifference = targetScale - transform.localScale;
        while (scaleDifference.magnitude > 0.1f)
        {
            transform.localScale += scaleDifference.normalized * animationSpeed;
            scaleDifference = targetScale - transform.localScale;
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
