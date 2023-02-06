using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring1_ForceUpdate : MonoBehaviour
{
    public Vector3 initialVeclocity;
    private Rigidbody rb;
    private MyForceManager ofer;
    public Vector3 theForce;

    private void Awake()
    {
        transform.position = new Vector3(2, 0, 0);
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
        theForce = ofer.Forces1;
        rb.AddForce(theForce);
    }
}
