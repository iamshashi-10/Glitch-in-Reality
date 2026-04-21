using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    public Image fadeScreen;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(Fade(1, 0));
    }

    IEnumerator Fade(float start, float end)
    {
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            float alpha = Mathf.Lerp(start, end, t / fadeDuration);

            fadeScreen.color = new Color(1, 1, 1, alpha);

            yield return null;
        }

        fadeScreen.color = new Color(1, 1, 1, end);
    }
}