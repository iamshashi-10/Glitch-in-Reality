using UnityEngine;

public class InfoButtonScript : MonoBehaviour
{
    public GameObject captionText;
    public void TurnOnCaption()
    {
        // Toggle ON/OFF
        captionText.SetActive(!captionText.activeSelf);
    }
}
