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
    public void LoadBlackhole()
    {
        SceneManager.LoadScene("Black_hole");
    }
    public void LoadAsteroid()
    {
        SceneManager.LoadScene("Asteroid");
    }
    public void LoadBb()
    {
        SceneManager.LoadScene("beforeBisphot");
    }
    public void LoadOM()
    {
        SceneManager.LoadScene("Orbital_Mechanics");
    }
}