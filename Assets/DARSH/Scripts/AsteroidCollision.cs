using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [Header("Flight Settings")]
    public Transform earthTarget;
    public float speed = 500f;

    [Header("Visual Effects")]
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
        if (collision.gameObject.name == "Earth")
        {
            if (explosionPrefab != null)
            {
                // Calculate the exact direction from the asteroid straight into the Earth's core
                Vector3 intoEarth = (earthTarget.position - transform.position).normalized;
                
                // Spawn the explosion facing directly into the dirt
                Instantiate(explosionPrefab, transform.position, Quaternion.LookRotation(intoEarth));
            }
            
            gameObject.SetActive(false);
        }
    }
}