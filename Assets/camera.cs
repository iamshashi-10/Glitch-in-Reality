using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 100f;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private bool canMove = false;

    // Assign Start Button from Inspector (optional)
    public Button startButton;

    void Start()
    {
        // Store initial position & rotation
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;

        Debug.Log("Game Started - Camera Ready");
    }

    void Update()
    {
        if (!canMove) return;

        float moveForward = 0f;
        float rotate = 0f;

        // Forward / Backward
        if (Input.GetKey(KeyCode.W)) moveForward = 1f;
        if (Input.GetKey(KeyCode.S)) moveForward = -1f;

        // Rotate Left / Right
        if (Input.GetKey(KeyCode.A)) rotate = -1f;
        if (Input.GetKey(KeyCode.D)) rotate = 1f;

        // Move forward in facing direction
        transform.Translate(Vector3.forward * moveForward * speed * Time.deltaTime);

        // Rotate like spacecraft
        transform.Rotate(Vector3.up * rotate * rotationSpeed * Time.deltaTime);
    }

    // ▶️ Start Tracking Button
    public void StartTracking()
    {
        Debug.Log("Start Tracking button clicked");

        canMove = true;

        // Disable button after click (optional)
        if (startButton != null)
            startButton.interactable = false;
    }

    // 🔁 Reset Button
    public void ResetCamera()
    {
        Debug.Log("Reset button clicked");

        // Reset position & rotation
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;

        // Stop movement
        canMove = false;

        // Enable Start button again (optional)
        if (startButton != null)
            startButton.interactable = true;

        Debug.Log("Camera reset to: " + defaultPosition);
    }
}