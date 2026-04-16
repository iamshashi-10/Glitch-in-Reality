using UnityEngine;
using UnityEngine.SceneManagement; // Needed for switching/restarting scenes

public class RocketControl : MonoBehaviour
{
    public float speed = 0.5f;
    public ParticleSystem fire;
    bool isFlying = false;

    public void Launch() 
    {
        if (!isFlying) 
        {
            isFlying = true; 
            if (fire != null) fire.Play();
        }
    }

    // --- NEW FUNCTIONS FOR YOUR BUTTONS ---

    public void IncreaseSpeed() { speed += 2f; }

    public void DecreaseSpeed() { speed = Mathf.Max(0, speed - 2f); }


 


    public void ExploreSpace() 
    {
        // Replace "FriendSceneName" with the actual name of your friend's scene
        SceneManager.LoadScene("FriendSceneName"); 
    }

    void Update() 
{
    // Add this back so the keyboard still works!
    if (Input.GetKeyDown(KeyCode.Return)) 
    {
        Launch();
    }

    if (isFlying)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    // WASD Steering
    // float horizontal = Input.GetAxis("Horizontal");
    // float vertical = Input.GetAxis("Vertical");
    // transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime, Space.World);
}

 
}