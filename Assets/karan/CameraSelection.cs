using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;

    public void SwitchCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }

        cameras[index].SetActive(true);
    }
}