using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring2_ForceUpdate : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 initialVeclocity;

    private MyForceManager ofer;
    public Vector3 theForce;

    private void Awake()
    {
        transform.position = new Vector3(-2, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVeclocity = new Vector3(0, 0, 0);
        rb.transform.position = transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
         ofer = FindObjectOfType<MyForceManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theForce = ofer.Forces2;
        rb.AddForce(theForce);
    }
}
