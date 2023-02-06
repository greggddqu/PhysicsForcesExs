using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public Vector3 initialVeclocity;
    private Rigidbody rb;

    public GravForceManager ofer;
    public Vector3 theForce;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVeclocity = new Vector3(0, 0, 0);

        ofer = FindObjectOfType<GravForceManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theForce = ofer.Forces1;
        rb.AddForce(theForce);
    }
}
