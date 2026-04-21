using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public GameObject captionText;
    public void TurnOnCaption()
    {
        // Toggle ON/OFF
        captionText.SetActive(!captionText.activeSelf);
    }
}