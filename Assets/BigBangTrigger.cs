using UnityEngine;
using UnityEngine.InputSystem; // We need this for VR controllers!

public class BigBangTrigger : MonoBehaviour
{
    [Header("Assign Your VR Button Here")]
    public InputActionReference vrTriggerButton;

    private ParticleSystem[] allParticles;

    void Start()
    {
        allParticles = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem ps in allParticles)
        {
            ps.Stop();
        }

        // Turn on the VR button listener
        if (vrTriggerButton != null)
        {
            vrTriggerButton.action.Enable();
            vrTriggerButton.action.performed += TriggerExplosion;
        }
    }

    private void OnDestroy()
    {
        // Clean up the listener when the game stops to prevent memory leaks
        if (vrTriggerButton != null)
        {
            vrTriggerButton.action.performed -= TriggerExplosion;
        }
    }

    // Notice we added the context parameter here, which the input system requires
    void TriggerExplosion(InputAction.CallbackContext context)
    {
        Debug.Log("VR Trigger Pulled! BOOM!");

        foreach (ParticleSystem ps in allParticles)
        {
            ps.Simulate(0.0f, true, true);
            ps.Play();
        }
    }
}