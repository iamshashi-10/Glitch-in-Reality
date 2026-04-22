using UnityEngine;
using UnityEngine.UI;
using TMPro; // add this


public class timeC : MonoBehaviour
{
    public MoonOnly solarSystem;
    public Slider slider;
    public TextMeshProUGUI speedText;
    // ❌ No 0 here → avoids freeze
    public float[] speedLevels = { 0.1f, 0.5f, 0.75f, 1f, 4f, 10f, 20f };

    void Start()
    {
        slider.value = 0; // default = 1x

        slider.onValueChanged.AddListener(UpdateTimeScale);

        UpdateTimeScale(slider.value);
    }

    void UpdateTimeScale(float value)
    {
        int index = (int)value;
        float speed = speedLevels[index];

        solarSystem.timeScale = speed;

        speedText.text = "Playback Speed: " + speed.ToString("0.##") + "x";
    }
}