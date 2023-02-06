using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForceN : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Rigidbody rb;
    public List<ParticleSpringN> particleList;
    private SphereCollider coll;

    private float springConstant;
    private float equilibriumDistance;
    //private float displacementDistance;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //displacementDistance = SpawnerSPRING.S.displacementDistance;
        equilibriumDistance = SpawnerSPRING.S.equilibriumDistance;
        springConstant = SpawnerSPRING.S.springConstant;
 
        particleList = new List<ParticleSpringN>();
        coll = GetComponent<SphereCollider>();
        coll.radius = 2.0f * equilibriumDistance;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ParticleSpringN b = other.GetComponent<ParticleSpringN>();
        if (b != null)
        {
            if (particleList.IndexOf(b) != -1)
            {
                particleList.Remove(b);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        ParticleSpringN b = other.GetComponent<ParticleSpringN>();
        if (b != null)
        {
            if (particleList.IndexOf(b) != -1)
            {
                particleList.Remove(b);
            }
        }
    }

    public Vector3 SumForces
    {
        get
        {
            Vector3 forces = Vector3.zero;
            Vector3 delta;
            int nearCount = 0;
            for (int i = 0; i < particleList.Count; i++)
            {
                delta = particleList[i].pos - transform.position;
                delta += delta - delta.normalized*equilibriumDistance;
                forces += delta*springConstant;
                nearCount++;
            }

            return forces;
        }
    }
}
