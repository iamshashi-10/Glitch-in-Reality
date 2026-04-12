using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public float speed = 5f;
    public ParticleSystem fire;
    bool isFlying = false;

    // This stays the same, but now we can also trigger it via code!
    public void Launch()
    {
        if (!isFlying) // Only start if we aren't already flying
        {
            isFlying = true;
            if (fire != null) fire.Play();
            Debug.Log("Ignition Sequence Start!");
        }
    }

    void Update()
    {
        // --- NEW PART: Listening for the Enter Key ---
        // In Unity, the Enter key is called "Return"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Launch(); // Call the same Launch function we used for the button!
        }

        // --- Movement Logic ---
        if (isFlying)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }

        // Steering with WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime, Space.World);
    }
}