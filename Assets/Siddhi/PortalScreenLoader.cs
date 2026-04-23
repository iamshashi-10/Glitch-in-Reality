// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PortalSceneLoader : MonoBehaviour
// {
//     public string sceneToLoad;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             SceneManager.LoadScene(sceneToLoad);
//         }
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide/Disable the player so it doesn't interfere with the new scene's camera
            other.gameObject.SetActive(false);
            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}