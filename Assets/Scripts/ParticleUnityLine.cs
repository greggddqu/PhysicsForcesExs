using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleUnityLine : MonoBehaviour
{
    public Rigidbody rb;
    public int myIndex;

    // Start is called before the first frame update
    void Start()
    {
        //set the initial position of a spawned particle
        //transform.position = Random.insideUnitSphere * 2.0f + Vector3.up * 2;
        //set initial velocity of the spawned particle
        //initialVel = 0.0f * Vector3.one;
        rb = GetComponent<Rigidbody>(); 
    }

}
