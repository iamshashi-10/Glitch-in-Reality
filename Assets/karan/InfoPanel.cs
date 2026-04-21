using UnityEngine;

public class InfoToggle : MonoBehaviour
{
    public GameObject infoPanel;

    public void ToggleInfo()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}