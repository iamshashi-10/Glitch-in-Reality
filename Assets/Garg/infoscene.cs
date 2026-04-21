using UnityEngine;

public class ToggleCaption : MonoBehaviour
{
    public GameObject captionText;

    public void ToggleCaptionVisibility()
    {
        // Toggle ON/OFF
        captionText.SetActive(!captionText.activeSelf);
    }
}