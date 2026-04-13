using UnityEngine;

public class ChaseAsteroid : MonoBehaviour
{
    [Header("Targets")]
    public Transform asteroid;
    public Transform earthTarget; // Add this so the camera knows where Earth is

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 10, -50); 
    public float stopDistance = 900f; // How far from Earth the camera should stop

    private bool hasStopped = false;

    void Update()
    {
        // 1. Check if we have an asteroid to follow
        if (asteroid != null && asteroid.gameObject.activeInHierarchy && !hasStopped)
        {
            // 2. Check how far we are from Earth
            float distanceToEarth = Vector3.Distance(transform.position, earthTarget.position);

            if (distanceToEarth > stopDistance)
            {
                // Follow logic
                transform.position = asteroid.position + asteroid.TransformDirection(offset);
                transform.rotation = asteroid.rotation;
            }
            else
            {
                // We reached the stop zone! 
                hasStopped = true;
            }
        }
        
        // 3. If we've stopped, stay put and look at the impact site
        if (hasStopped && earthTarget != null)
        {
            transform.LookAt(earthTarget.position);
        }
    }
}