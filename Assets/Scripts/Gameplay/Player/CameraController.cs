using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed = 3f;
    public float smoothTime = 0.1f;

    private float currentX;
    private float currentY;
    private Vector3 currentVelocity;
    private InputHandler inputHandler;

    void Start()
    {
        if (target != null)
        {
            inputHandler = target.GetComponent<InputHandler>();
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (inputHandler != null)
        {
            currentX += inputHandler.LookInput.x * rotationSpeed;
            currentY -= inputHandler.LookInput.y * rotationSpeed;
        }
        else
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        }
        currentY = Mathf.Clamp(currentY, -35f, 60f);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPos = target.position + rotation * new Vector3(0, 0, -distance);
        desiredPos += Vector3.up * height;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, smoothTime);
        transform.LookAt(target.position + Vector3.up * height);
    }
}
