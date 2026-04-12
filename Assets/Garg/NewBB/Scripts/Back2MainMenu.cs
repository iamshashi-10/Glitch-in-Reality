using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2MainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Spacecraft_interaction"); // ⚠️ EXACT scene name
    }
}