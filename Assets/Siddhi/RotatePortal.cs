using UnityEngine;

public class RotatePortal : MonoBehaviour
{
    public float rotationSpeed = 40f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}