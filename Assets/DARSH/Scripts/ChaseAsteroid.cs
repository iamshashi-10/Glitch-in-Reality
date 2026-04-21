using UnityEngine;

public class ChaseAsteroid : MonoBehaviour
{
    [Header("Targets")]
    public Transform asteroid;
    public Transform earthTarget; 

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 10, -50); 
    public float stopDistance = 7000f; 

    private bool hasStopped = false;
    
    // 1. NEW: This acts as the lock. It is false until the button is clicked.
    private bool isChasing = false; 

    void Update()
    {
        // 2. NEW: If the button hasn't been clicked yet, stop reading the rest of the code.
        if (isChasing == false) 
        {
            return; 
        }

        // --- The rest of your original logic stays exactly the same! ---
        if (asteroid != null && asteroid.gameObject.activeInHierarchy && !hasStopped)
        {
            float distanceToEarth = Vector3.Distance(transform.position, earthTarget.position);

            if (distanceToEarth > stopDistance)
            {
                transform.position = asteroid.position + asteroid.TransformDirection(offset);
                transform.LookAt(earthTarget.position);
            }
            else
            {
                hasStopped = true;
            }
        }
        
        if (hasStopped && earthTarget != null)
        {
            transform.LookAt(earthTarget.position);
        }
    }

    // 3. NEW: This must be a "public" function so the UI Button can see it
    public void TriggerChase()
    {
        // When the button is clicked, unlock the Update loop!
        isChasing = true;
    }
}