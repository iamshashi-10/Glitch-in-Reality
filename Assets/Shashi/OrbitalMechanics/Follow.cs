using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    public float distance = 30f;
    public Vector3 offset = new Vector3(0, 5, 0); // only X & Y offset
    public float smoothSpeed = 5f;

    // Cache the rigidbody here so we don't lag the game searching for it every frame
    private Rigidbody targetRb;

    void Start()
    {
        if (target != null)
        {
            targetRb = target.GetComponent<Rigidbody>();
        }
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = (targetRb != null) ? targetRb.position : target.position;

            // ✅ compute final offset using distance
            Vector3 finalOffset = offset + new Vector3(0, 0, -distance);

            Vector3 desiredPosition = targetPosition + finalOffset;

            //remove the bottom two if running the 1)line 
            transform.position = desiredPosition;
            transform.LookAt(targetPosition);

            // ✅ Actually use the smoothSpeed variable for buttery smooth movement!
            // 1)
            // transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // ❌ REMOVED: transform.LookAt(targetPosition);
            // In VR, we never force rotation. We let the player naturally turn their head to look at the Earth!
        }
    }
    public void StopFollowing()
    {
        target = null;
        targetRb = null;
    }

}