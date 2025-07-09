using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private InputHandler inputHandler;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();
    }

    void Update()
    {
        Vector3 move = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small downward force to keep grounded
        }

        if (inputHandler.JumpPressed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
