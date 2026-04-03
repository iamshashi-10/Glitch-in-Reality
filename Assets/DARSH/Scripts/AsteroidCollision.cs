using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [Header("Flight Settings")]
    public Transform earthTarget;
    public float speed = 500f;

    [Header("Visual Effects")]
    // 1. THIS IS THE NEW LINE: It creates the empty slot in the Inspector
    public GameObject explosionPrefab; 

    void Update()
    {
        if (earthTarget != null)
        {
            // Move the asteroid toward the Earth
            Vector3 direction = (earthTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the thing we hit is actually the Earth
        if (collision.gameObject.name == "Earth")
        {
            Debug.Log("IMPACT!");
            
            // 2. THIS IS THE NEW LOGIC: It spawns the explosion prefab
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            
            // 3. Hide the massive rock so it doesn't block the fire
            gameObject.SetActive(false);
        }
    }
}