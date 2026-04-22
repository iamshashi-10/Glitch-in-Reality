using System.Collections; // Required for Coroutines
using UnityEngine;
using Unity.XR.CoreUtils;

public class XRObservationSetup : MonoBehaviour
{
    [Tooltip("Drag your XR Origin here")]
    public XROrigin xrOrigin;
    
    [Tooltip("Drag your ObservationSpawnPoint here")]
    public Transform observationPoint;

    void Start()
    {
        if (xrOrigin != null && observationPoint != null)
        {
            // Start the delay process instead of doing it immediately
            StartCoroutine(SnapCameraAfterTrackingInit());
        }
        else
        {
            Debug.LogWarning("XRObservationSetup is missing references!");
        }
    }

    private IEnumerator SnapCameraAfterTrackingInit()
    {
        // Wait for the end of the first frame. 
        // This gives the XR Device Simulator time to apply its leftover tracking data first.
        yield return new WaitForEndOfFrame();
        
        // If it's still being stubborn, you can uncomment the line below to force a 0.1 second wait instead:
        // yield return new WaitForSeconds(0.1f);

        // NOW we force the camera to the spawn point, overwriting the simulator's bad data.
        xrOrigin.MoveCameraToWorldLocation(observationPoint.position);
        xrOrigin.MatchOriginUpCameraForward(observationPoint.up, observationPoint.forward);
        
        Debug.Log("XR Camera successfully snapped to Observation Point after initialization.");
    }
}