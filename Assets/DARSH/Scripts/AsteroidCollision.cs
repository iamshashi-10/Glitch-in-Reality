using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [Header("Flight Settings")]
    public Transform earthTarget;
    public float speed = 500f; // High speed to cross the massive distance

    void Update()
    {
        if (earthTarget != null)
        {
            // 1. Find the exact direction pointing at the Earth
            Vector3 direction = (earthTarget.position - transform.position).normalized;
            
            // 2. Move the asteroid smoothly along that path
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("Please assign the Earth target in the Inspector!");
        }
    }

    // 3. Detect the moment of impact
    void OnCollisionEnter(Collision collision)
    {
        // Verify it actually hit the Earth and not something else
        if (collision.gameObject.name == "Earth")
        {
            Debug.Log("IMPACT LOGGED: Asteroid has struck the Earth boundary.");
            
            // Hide the asteroid to confirm the physics trigger works
            gameObject.SetActive(false);
        }
    }
}