using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadeScreen;

    public float delayBeforeFade = 3f;
    public float fadeDuration = 2f;

    public string nextSceneName;

    void Start()
    {
        StartCoroutine(LoadSequence());
    }

    IEnumerator LoadSequence()
    {
        // wait for explosion
        yield return new WaitForSeconds(delayBeforeFade);

        // fade to white
        yield return StartCoroutine(Fade(0, 1));

        // load next scene
        SceneManager.LoadScene(nextSceneName);
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