using UnityEngine;

public class ImpactFlash : MonoBehaviour
{
    [Header("Flash Settings")]
    public float fadeSpeed = 300f; // How fast the light dies (higher = faster)
    
    private Light flashLight;

    void Start()
    {
        // Grab the light component as soon as it spawns
        flashLight = GetComponent<Light>();
    }

    void Update()
    {
        // Rapidly drain the light's intensity every frame until it hits zero
        if (flashLight != null && flashLight.intensity > 0)
        {
            flashLight.intensity -= fadeSpeed * Time.deltaTime;
        }
    }
}