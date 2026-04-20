using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset sceneAsset;
#endif

    private string sceneName;

    private void Awake()
    {
#if UNITY_EDITOR
        sceneName = sceneAsset.name;
#endif
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}