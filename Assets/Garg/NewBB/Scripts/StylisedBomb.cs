using UnityEngine;
using UnityEngine.VFX;

public class StylisedBomb : MonoBehaviour
{
    [SerializeField] private VisualEffect sparkParticles;

    public void StartExplosion()
    {
        if (sparkParticles != null)
        {
            sparkParticles.Play();
        }
        else
        {
            Debug.LogError("SparkParticles NOT assigned!");
        }
    }
}