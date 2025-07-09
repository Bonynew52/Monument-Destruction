using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MoveInput = new Vector2(horizontal, vertical);

        JumpPressed = Input.GetButtonDown("Jump");
    }
}
