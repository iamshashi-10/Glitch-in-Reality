using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    //real value of gravitational constant is 6.67408 × 10-11
    //can increase to make thing go faster instead of increase timestep of Unity
    // [SerializeField]
    // float G = 4000f;
    GameObject[] celestial;
    [Range(0f, 50f)]
    public float timeScale = 1f;

    [SerializeField]
    private float G = 4000f;
    [SerializeField]
    bool IsElipticalOrbit = false;
    
    [SerializeField]
    private float earthRotationSpeed = 50f;
    Rigidbody[] bodies;
    GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        celestial = GameObject.FindGameObjectsWithTag("celestials");
        SetInitialVelocity();
        bodies = new Rigidbody[celestial.Length];
        for (int i = 0; i < celestial.Length; i++)
        {
            bodies[i] = celestial[i].GetComponent<Rigidbody>();
        }
        foreach (GameObject obj in celestial)
        {
            if (obj.name == "EarthObject")
            {
                earth = obj;
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time.timeScale = timeScale;
        //  IMPORTANT: keep physics stable with timescale
        // Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Gravity();
        if (earth != null)
        {
            Rigidbody rb = earth.GetComponent<Rigidbody>();
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * earthRotationSpeed * Time.fixedDeltaTime));
        }
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
                    // transform.Rotate(Vector3.up * 20f * Time.deltaTime);
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

    // void Gravity()
    // {
    //     foreach (GameObject a in celestial)
    //     {
    //         foreach (GameObject b in celestial)
    //         {
    //             if (!a.Equals(b))
    //             {
    //                 float m1 = a.GetComponent<Rigidbody>().mass;
    //                 float m2 = b.GetComponent<Rigidbody>().mass;
    //                 float r = Vector3.Distance(a.transform.position, b.transform.position);

    //                 if (r > 0.1f)
    //                 {
    //                     a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
    //                 }
    //             }
    //         }
    //     }
    // }
    void Gravity()
    {
        int count = bodies.Length;

        for (int i = 0; i < count; i++)
        {
            for (int j = i + 1; j < count; j++) // ✅ avoid duplicate pairs
            {
                Vector3 dir = bodies[j].position - bodies[i].position;
                float r = dir.magnitude;

                if (r > 0.1f)
                {
                    Vector3 forceDir = dir.normalized;
                    float forceMag = G * (bodies[i].mass * bodies[j].mass) / (r * r);

                    Vector3 force = forceDir * forceMag;

                    // ✅ apply equal and opposite force
                    bodies[i].AddForce(force);
                    bodies[j].AddForce(-force);
                }
            }
        }
    }
}