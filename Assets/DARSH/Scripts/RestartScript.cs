using UnityEngine;
using UnityEngine.SceneManagement; // This line is REQUIRED to load levels!

public class RestartScript : MonoBehaviour
{
    // This is a public function so the physical button can "see" it and click it
    public void RestartSimulation()
    {
        // This looks at whatever scene you are currently in, and reloads it fresh from frame 0
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}