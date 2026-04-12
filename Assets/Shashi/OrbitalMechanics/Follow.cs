using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    public float distance = 15f;
    public Vector3 offset = new Vector3(0, 5, 0); // only X & Y offset
    public float smoothSpeed = 5f;

    void FixedUpdate()
    {
        if (target != null)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            Vector3 targetPosition = (rb != null) ? rb.position : target.position;

            // ✅ compute final offset using distance
            Vector3 finalOffset = offset + new Vector3(0, 0, -distance);

            Vector3 desiredPosition = targetPosition + finalOffset;

            transform.position = desiredPosition;
            transform.LookAt(targetPosition);
        }
    }
    public void StopFollowing()
    {
        target = null;
    }

}