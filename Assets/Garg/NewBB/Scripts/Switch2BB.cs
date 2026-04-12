using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch2BB : MonoBehaviour
{
    public void LoadBB()
    {
        SceneManager.LoadScene("Bisphot"); // ⚠️ EXACT scene name
    }
}