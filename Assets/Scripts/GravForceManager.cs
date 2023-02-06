using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravForceManager : MonoBehaviour
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
    public float gravitationConstant = 10.0f;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        rb1 = SphereOne.GetComponent<Rigidbody>();
        rb2 = SphereTwo.GetComponent<Rigidbody>();
        Pos1 = SphereOne.transform.position;
        Pos2 = SphereTwo.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mass1 = rb1.mass;
        mass2 = rb2.mass;
        forceDirection = Pos1 - Pos2;
        radius = forceDirection.magnitude * forceDirection.magnitude;
        Forces1 = -gravitationConstant * mass1 * mass2 * forceDirection.normalized / radius;
        Forces2 = -Forces1;
        Pos1 = SphereOne.transform.position;
        Pos2 = SphereTwo.transform.position;

    }
}
