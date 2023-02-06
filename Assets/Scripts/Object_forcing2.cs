using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_forcing2 : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 initialVeclocity;
   
    public GravForceManager ofer;
    public Vector3 theForce;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVeclocity = new Vector3(0, 3, 0);

        ofer = FindObjectOfType<GravForceManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theForce = ofer.Forces2;
        rb.AddForce(theForce);
    }
}
