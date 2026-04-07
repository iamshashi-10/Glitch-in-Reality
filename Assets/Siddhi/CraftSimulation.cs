using UnityEngine;

public class SpacecraftControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");     // ↑ ↓
        float turn = Input.GetAxis("Horizontal");   // ← →

        // Move forward/back in facing direction
        Vector3 forwardMove = transform.forward * move * moveSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, 0f, forwardMove.z);

        // Rotate left/right
        Quaternion turnRotation = Quaternion.Euler(0f, turn * rotationSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}