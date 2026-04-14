using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class ReturnScript : MonoBehaviour
{
    [Header("Scene Settings")]
    public string mainSceneName = "Spacecraft_interaction";

    // The function the button will click
    public void ReturnToMainScene()
    {
        // Tell Unity to load the scene name you typed in the Inspector
        SceneManager.LoadScene(mainSceneName);
    }
}