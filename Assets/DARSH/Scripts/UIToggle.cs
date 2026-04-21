using UnityEngine;

public class UIToggle : MonoBehaviour
{
    [Header("The Panel to Toggle")]
    public GameObject targetPanel;

    // This function will be triggered by your button
    public void ToggleVisibility()
    {
        // First, check to make sure you actually assigned a panel in the Inspector
        if (targetPanel != null)
        {
            // Find out if the panel is currently turned on or off
            bool isCurrentlyOn = targetPanel.activeSelf;

            // Set the panel to the exact OPPOSITE of what it currently is
            targetPanel.SetActive(!isCurrentlyOn);
        }
    }
}