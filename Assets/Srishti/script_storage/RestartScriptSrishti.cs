using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScriptSrishti : MonoBehaviour
{
    public void RestartScene()
    {
        // 1. Clear any weird states
        Time.timeScale = 1f; 
        
        // 2. Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        // 3. Optional: Manually clear the console via code if you want
        Debug.ClearDeveloperConsole(); 
    }
}