using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale when returning to main menu
        SceneManager.LoadScene("Spacecraft_interaction"); // ⚠️ EXACT scene name
    }
    public void LoadSolarEclipse()
    {
        Time.timeScale = 1f; // Reset time scale when starting solar eclipse scene
        SceneManager.LoadScene("Solar_Eclipse"); // ⚠️ EXACT scene name
    }
}