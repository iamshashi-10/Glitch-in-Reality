using System.Collections;
using UnityEngine;

public class BigBangCinematicController : MonoBehaviour
{
    [Header("Objects")]
    public Transform coreFlash;
    public Transform shockWaveRing;
    public Transform explosionCloud;
    public ParticleSystem explosionParticles;
    public ParticleSystem cosmicDust;
    public Light pointLight;

    [Header("Timings")]
    public float totalDuration = 3.5f;
    public float coreTime = 0.25f;
    public float ringStartDelay = 0.08f;
    public float cloudStartDelay = 0.18f;
    public float particlesStartDelay = 0.85f;
    public float dustStartDelay = 1.25f;

    [Header("Scales")]
    public float coreStartScale = 0.05f;
    public float coreEndScale = 3.5f;

    public float ringStartScale = 0.08f;
    public float ringEndScale = 25f;

    public float cloudStartScale = 0.12f;
    public float cloudEndScale = 18f;

    [Header("Light")]
    public float lightPeakIntensity = 80f;
    public float lightFadeTime = 1.2f;
    public Color lightColor = new Color(1f, 0.92f, 0.78f);

    Vector3 coreBaseScale;
    Vector3 ringBaseScale;
    Vector3 cloudBaseScale;

    void Awake()
    {
        if (coreFlash) coreBaseScale = coreFlash.localScale;
        if (shockWaveRing) ringBaseScale = shockWaveRing.localScale;
        if (explosionCloud) cloudBaseScale = explosionCloud.localScale;
    }

    void Start()
    {
        PlayExplosion();
    }

    public void PlayExplosion()
    {
        StopAllCoroutines();
        ResetAll();
        StartCoroutine(ExplosionRoutine());
    }

    void ResetAll()
    {
        if (coreFlash) coreFlash.localScale = coreBaseScale * coreStartScale;
        if (shockWaveRing) shockWaveRing.localScale = ringBaseScale * ringStartScale;
        if (explosionCloud) explosionCloud.localScale = cloudBaseScale * cloudStartScale;

        if (explosionParticles)
            explosionParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        if (cosmicDust)
            cosmicDust.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        if (pointLight)
        {
            pointLight.enabled = true;
            pointLight.intensity = 0f;
            pointLight.color = lightColor;
        }
    }

    IEnumerator ExplosionRoutine()
    {
        float t = 0f;

        if (coreFlash) coreFlash.gameObject.SetActive(true);
        if (shockWaveRing) shockWaveRing.gameObject.SetActive(true);
        if (explosionCloud) explosionCloud.gameObject.SetActive(true);

        while (t < totalDuration)
        {
            t += Time.deltaTime;

            // Core flash: very fast rise, then fade
            if (coreFlash)
            {
                float coreGrow = Mathf.Clamp01(t / coreTime);
                float coreScale = Mathf.Lerp(coreStartScale, coreEndScale, EaseOutCubic(coreGrow));
                coreFlash.localScale = coreBaseScale * coreScale;
            }

            // Shock ring: starts after a short delay and expands outward slowly
            if (shockWaveRing)
            {
                float ringT = Mathf.Clamp01((t - ringStartDelay) / 1.25f);
                float ringScale = Mathf.Lerp(ringStartScale, ringEndScale, EaseOutCubic(ringT));
                shockWaveRing.localScale = ringBaseScale * ringScale;
            }

            // Cloud: slower, softer bloom
            if (explosionCloud)
            {
                float cloudT = Mathf.Clamp01((t - cloudStartDelay) / 1.8f);
                float cloudScale = Mathf.Lerp(cloudStartScale, cloudEndScale, EaseOutCubic(cloudT));
                explosionCloud.localScale = cloudBaseScale * cloudScale;
            }

            // Light pulse: quick peak, then fade
            if (pointLight)
            {
                if (t < 0.12f)
                {
                    pointLight.intensity = Mathf.Lerp(0f, lightPeakIntensity, t / 0.12f);
                }
                else
                {
                    float fadeT = Mathf.Clamp01((t - 0.12f) / lightFadeTime);
                    pointLight.intensity = Mathf.Lerp(lightPeakIntensity, 0f, fadeT);
                }
            }

            // Delayed sparks
            if (t >= particlesStartDelay && explosionParticles && !explosionParticles.isPlaying)
                explosionParticles.Play();

            // Delayed dust
            if (t >= dustStartDelay && cosmicDust && !cosmicDust.isPlaying)
                cosmicDust.Play();

            yield return null;
        }

        if (pointLight)
            pointLight.intensity = 0f;
    }

    float EaseOutCubic(float x)
    {
        x = Mathf.Clamp01(x);
        return 1f - Mathf.Pow(1f - x, 3f);
    }
}