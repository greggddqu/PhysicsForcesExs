using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForcing : MonoBehaviour
{
    public Vector3 initialPos;
    public Vector3 initialVel;
    Rigidbody rb;
    Vector3 theForce;
    float SpringK; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialVel = Vector3.up;
        SpringK = 10.0f;
        rb.velocity = initialVel;
        
    }

    // Update is called once per frame
    void Update()
    {
        theForce = -SpringK * transform.position;
        rb.AddForce(theForce);
    }
}
