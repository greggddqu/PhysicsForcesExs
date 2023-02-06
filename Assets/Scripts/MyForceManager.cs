using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyForceManager : MonoBehaviour
{
    public GameObject SphereOne;
    Rigidbody rb1;
    public GameObject SphereTwo;
    Rigidbody rb2;

    public Vector3 Forces1;
    public Vector3 Forces2;
    public Vector3 Pos1;
    public Vector3 Pos2;
    public Vector3 forceDirection;
    public float mass1;
    public float mass2;
    public float springConstant;
    public float equilibriumSpringLength;
    public float dX;

    private void Awake()
    {
        equilibriumSpringLength = 6.0f;
        springConstant = 10.0f;
        //Time.fixedDeltaTime = Time.fixedDeltaTime / 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb1 = SphereOne.GetComponent<Rigidbody>();
        rb2 = SphereTwo.GetComponent<Rigidbody>();
        mass1 = rb1.mass;
        mass2 = rb2.mass;
        Pos1 = SphereOne.transform.position;
        Pos2 = SphereTwo.transform.position;
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Pos1, Pos2 " + Pos1 + Pos2);
        forceDirection =  Pos1 - Pos2;
        forceDirection = forceDirection - forceDirection.normalized * equilibriumSpringLength;
        Forces1 = -springConstant * forceDirection;
        Forces2 = -Forces1;
        Pos1 = SphereOne.transform.position;
        Pos2 = SphereTwo.transform.position;
    }
}
