using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSPRING : MonoBehaviour
{
    //This is a Singleton of the particle Spawner. there is only one instance 
    // of this Spawner, so we can store it in a static variable named s.
    static public SpawnerSPRING S;
    static public List<ParticleSpringN> ParticleSpringNs;

    // These fields allow you to adjust the spawning behavior of the spheres
    [Header("Set in Inspector: Spawning")]
    public GameObject particleSpringPrefab;
    public Transform particleAnchor;
    public int numParticles = 10;
    public float displacementDistance = 14.0f;
    public float spawnDelay = 0.1f;
    public float initVel = 0.1f;

    //add variables here that spawned particles will inherit
    [Header("Set in Inspector: Springs")]
    public float springConstant = 20.0f;
    public float equilibriumDistance = 10.0f;
    private float particlDisplacement = 4.0f;
    Vector3 initPos;
    void Awake()
    {
        //Set the Singleton S to be this instance of particle spawner
        S = this;
        //Start instantiation of the particles
        ParticleSpringNs = new List<ParticleSpringN>();//the list holding the particles
        InstantiateParticleSpringN();
    }

    private void Start()
    {
        initPos = ParticleSpringNs[0].rb.transform.position;
    }
    private void FixedUpdate()
    {
        ParticleSpringNs[0].rb.transform.position = initPos + (4.0f * Mathf.Sin(8.0f * Mathf.PI * Time.deltaTime) * Vector3.right);

    }
    //a method to spawn the particles
    public void InstantiateParticleSpringN()
    {
        GameObject go = Instantiate(particleSpringPrefab);
        ParticleSpringN b = go.GetComponent<ParticleSpringN>();
        b.transform.SetParent(particleAnchor);
        particlDisplacement = equilibriumDistance - displacementDistance;
        b.rb.transform.position = particlDisplacement * Vector3.right * (0.0f * numParticles - ParticleSpringNs.Count);
        ParticleSpringNs.Add(b);
        if (ParticleSpringNs.Count < numParticles)
        {
            Invoke("InstantiateParticleSpringN", spawnDelay);
        }
    }
}
