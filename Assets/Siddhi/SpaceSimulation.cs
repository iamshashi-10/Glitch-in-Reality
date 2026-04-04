using UnityEngine;

public class SpaceSimulation : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 6f;
    public float height = 5f; // curve height

    private float timeElapsed;

    void Start()
    {
        transform.position = startPoint.position;
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            // SmoothStep (for realistic acceleration)
            t = t * t * (3f - 2f * t);

            // Create curved path
            Vector3 midPoint = (startPoint.position + endPoint.position) / 2 + Vector3.up * height;

            Vector3 m1 = Vector3.Lerp(startPoint.position, midPoint, t);
            Vector3 m2 = Vector3.Lerp(midPoint, endPoint.position, t);

            transform.position = Vector3.Lerp(m1, m2, t);

            // Rotate towards movement direction
            Vector3 direction = m2 - m1;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direction);

            timeElapsed += Time.deltaTime;
        }
    }
}