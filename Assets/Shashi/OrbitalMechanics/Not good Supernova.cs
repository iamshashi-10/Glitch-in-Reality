using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine;

public class Supernova : MonoBehaviour
{
    public float expansionSpeed = 50f;
    public float maxScale = 300f;
    public Light sunLight;
    [SerializeField]
    private bool explode = false;

    void Update()
    {
        if (explode)
        {
            transform.localScale += Vector3.one * expansionSpeed * Time.deltaTime;
            sunLight.intensity += 5f * Time.deltaTime; // glow boost
            if (transform.localScale.x > maxScale)
            {
                explode = false;
            }
            GameObject[] planets = GameObject.FindGameObjectsWithTag("celestials");

            foreach (GameObject obj in planets)
            {
                if (obj.name != "SunObject")
                {
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    Vector3 dir = (obj.transform.position - transform.position).normalized;

                    rb.AddForce(dir * 500f);
                }
                if (Vector3.Distance(obj.transform.position, transform.position) < transform.localScale.x)
                {
                    Destroy(obj);
                }
            }
        }
    }

    public void TriggerSupernova()
    {
        explode = true;
    }
}
