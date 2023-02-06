using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpringN : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Rigidbody rb;
    private SpringForceN springForceN;


    // Use this for initialization

    void Awake()
    {
        springForceN = GetComponent<SpringForceN>();
        rb = GetComponent<Rigidbody>();
        //set initial position randomly along (1,0,0)
        //pos = Vector3.right*Random.value * SpawnerSPRING.S.displacementDistance * SpawnerSPRING.S.numParticles;
        //Initial velocity randomly here also
        Vector3 vel = SpawnerSPRING.S.initVel * Random.value * Vector3.right; //tune 
        //rb.velocity = vel;
    }
    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }   
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 forcesOnMe = springForceN.SumForces;
        rb.AddForce(forcesOnMe);
    }
}
