using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animator animator;
    public StylisedBomb stylisedBomb;

    private bool triggered = false;

    void Start()
    {
        // FORCE start in idle state
        animator.Play("BombIdle");
    }

    public void TriggerExplosion()
    {
        Debug.Log("BUTTON CLICKED");

        if (!triggered)
        {
            animator.SetTrigger("Explode");

            if (stylisedBomb != null)
                stylisedBomb.StartExplosion();

            triggered = true;
        }
    }
}