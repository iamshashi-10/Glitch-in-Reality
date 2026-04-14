using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    [Header("Connections")]
    public AsteroidCollision asteroidScript; 
    public Slider speedSlider;               

    [Header("Speed Settings")]
    [Tooltip("Speeds for levels 0, 1, 2, 3, and 4 (Slow Mo -> Hyper Speed)")]
    // Here is your list! You can change these exact numbers in the Unity Inspector.
    public float[] speedLevels = new float[] { 150f, 300f, 500f, 1000f, 1500f }; 

    void Start()
    {
        if (speedSlider != null && asteroidScript != null)
        {
            // Foolproof the slider via code: Force it to only use 5 whole numbers (0 to 4)
            speedSlider.wholeNumbers = true;
            speedSlider.minValue = 0;
            speedSlider.maxValue = speedLevels.Length - 1; 

            // Set the slider to start in the middle (Index 2, which is 500f in the list)
            speedSlider.value = 2;
            asteroidScript.speed = speedLevels[2];
        }

        speedSlider.onValueChanged.AddListener(UpdateVelocity);
    }

    public void UpdateVelocity(float newSpeedIndex)
    {
        // The slider passes a float, so we convert it to an exact integer (0, 1, 2, 3, or 4)
        int index = Mathf.RoundToInt(newSpeedIndex);

        // Safety check to ensure the index actually exists in our list
        if (index >= 0 && index < speedLevels.Length)
        {
            // Assign the speed from our predefined list to the asteroid
            asteroidScript.speed = speedLevels[index];
        }
    }
}