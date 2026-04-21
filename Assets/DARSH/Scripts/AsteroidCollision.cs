using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [Header("Flight Settings")]
    public Transform earthTarget;
    public float speed = 500f;

    [Header("Visual Effects")]
    public GameObject explosionPrefab; 
    
    // 1. THIS IS THE NEW LINE: It creates the slot for your custom scorch material
    public Material scorchMaterial; 

    void Update()
    {
        if (earthTarget != null)
        {
            // Move the asteroid toward the Earth
            Vector3 direction = (earthTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // Check if the thing we hit is actually the Earth
    //     if (collision.gameObject.name == "Earth")
    //     {
    //         Debug.Log("IMPACT!");
            
    //         // Spawn the explosion prefab and save it as a variable named 'impact'
    //         if (explosionPrefab != null)
    //         {
    //             GameObject impact = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                
    //             // 2. THIS IS THE NEW LOGIC: Paint the spawned object with the scorch material
    //             if (scorchMaterial != null)
    //             {
    //                 // Using GetComponentInChildren just in case your Plane is a child of the particle system
    //                 Renderer renderer = impact.GetComponentInChildren<Renderer>();
    //                 if (renderer != null)
    //                 {
    //                     renderer.material = scorchMaterial;
    //                 }
    //             }
    //         }
            
    //         // Hide the massive rock so it doesn't block the fire
    //         gameObject.SetActive(false);
    //     }
    // }
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