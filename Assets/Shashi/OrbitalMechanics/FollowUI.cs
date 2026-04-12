using UnityEngine;

public class FollowUI : MonoBehaviour
{
    public Follow cameraFollow;

    // public Transform sun;
    public Transform earth;
    // public Transform moon;

    // public void FollowSun()
    // {
    //     cameraFollow.target = sun;
    // }

    // public void FollowEarth()
    // {
    //     cameraFollow.target = earth;
    // }
    public void FollowEarth()
{
    Debug.Log("Button Clicked");

    if (cameraFollow == null)
        Debug.LogError("cameraFollow is NULL");

    if (earth == null)
        Debug.LogError("earth is NULL");

    cameraFollow.target = earth;
}
    

    // public void FollowMoon()
    // {
    //     cameraFollow.target = moon;
    // }
}