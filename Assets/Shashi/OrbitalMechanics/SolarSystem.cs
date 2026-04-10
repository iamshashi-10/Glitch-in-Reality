using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    //real value of gravitational constant is 6.67408 × 10-11
    //can increase to make thing go faster instead of increase timestep of Unity
    readonly float G = 4000f;
    GameObject[] celestial;

    [SerializeField]
    bool IsElipticalOrbit = false;

    // Start is called before the first frame update
    void Start()
    {
        celestial = GameObject.FindGameObjectsWithTag("celestials");

        SetInitialVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gravity();
    }

    void SetInitialVelocity()
    {
        foreach (GameObject a in celestial)
        {
            Vector3 totalVelocity = Vector3.zero;
            foreach (GameObject b in celestial)
            {
                if(!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    Vector3 radiusVector = b.transform.position - a.transform.position;
                    float r = radiusVector.magnitude;

                    if (r > 0.1f)
                    {
                        // Calculate tangential direction (perpendicular to radius vector)
                        Vector3 tangentialDirection = Vector3.Cross(Vector3.up, radiusVector).normalized;
                        if (tangentialDirection.magnitude < 0.1f)
                            tangentialDirection = Vector3.Cross(Vector3.forward, radiusVector).normalized;

                        if (IsElipticalOrbit)
                        {
                            totalVelocity += tangentialDirection * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                        }
                        else
                        {
                            totalVelocity += tangentialDirection * Mathf.Sqrt((G * m2) / r);
                        }
                    }
                }
            }
            // Skip setting initial velocity for the Sun
            if (a.name != "SunObject")
            {
                a.GetComponent<Rigidbody>().linearVelocity = totalVelocity;
            }
            else
            {
                a.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
        }
    }

    void Gravity()
    {
        foreach (GameObject a in celestial)
        {
            foreach (GameObject b in celestial)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    if (r > 0.1f)
                    {
                        a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                    }
                }
            }
        }
    }
}