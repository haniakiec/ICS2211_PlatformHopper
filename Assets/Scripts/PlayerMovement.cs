using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D player;
    private bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Safety check so Unity doesn't crash if no keyboard is found
        if (Keyboard.current == null) return;

        if(Keyboard.current.enterKey.isPressed) Start();

        // 1. SIMPLE LEFT/RIGHT MOVEMENT
        float moveInput = 0f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f; // Move right
        }
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f; // Move left
        }

        player.linearVelocity = new Vector2(moveInput * moveSpeed, player.linearVelocity.y);

        // 2. SIMPLE JUMP
        if ((Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame )&& isGrounded)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
