using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLine : MonoBehaviour
{
    //This is a Singleton of the particle Spawner. there is only one instance 
    // of this Spawner, so we can store it in a static variable named s.
    static public SpawnerLine S;
    static public List<ParticleUnityLine> ParticleUnitys;

    // These fields allow you to adjust the spawning behavior of the spheres
    [Header("Set in Inspector: Spawning")]
    public GameObject particleUnityPrefab;
    public Transform particleAnchor;
    public int numParticles = 10;

    public List<Vector3> forceList;
    public float equilibriumSpringLength;
    public float springConstant;
    Vector3 initPos;
        

    void Awake()
    {
        //Set the Singleton S to be this instance of particle spawner
        S = this;

        //Construct a list to hold the particles
        ParticleUnitys = new List<ParticleUnityLine>();

        //Instantiate the particles
        InstantiateParticleUnitys();

        //Set force parameters
        equilibriumSpringLength = 2.0f;
        springConstant = 20.0f;
    }
    private void Start()
    {
    //ParticleUnitys[0].rb.constraints=RigidbodyConstraints.FreezePosition;
    //ParticleUnitys[numParticles - 1].rb.constraints = RigidbodyConstraints.FreezePosition;
    //ParticleUnitys[4].rb.velocity = 1.1f * Vector3.up;
    initPos = ParticleUnitys[0].rb.transform.position;
    }

    private void FixedUpdate()
    {
        //Apply the forces to the particles
        ParticleUnitys[0].rb.transform.position = initPos + (4.0f*Mathf.Sin(8.0f * Mathf.PI * Time.deltaTime) * Vector3.right);
        //ParticleUnitys[1].rb.AddForce(40.0f*Vector3.right*Mathf.Sin(4.0f*Mathf.PI*Time.deltaTime));
        //Calculate the forces
        forceList = ForceGetter();
        for (int i = 0; i < ParticleUnitys.Count; i++)
        {
            if (i == 0)
            {
                //ParticleUnitys[0].rb.AddForce(forceList[0]);
            }
            else if (i == ParticleUnitys.Count - 1)
            {
                
                //ParticleUnitys[i].rb.AddForce(-forceList[i-1]);
            }
            else
            {
                ParticleUnitys[i].rb.AddForce(-forceList[i - 1] + forceList[i]);
            }
        }
    }

    //a method to spawn the particles
    public void InstantiateParticleUnitys()
    {
        GameObject go = Instantiate(particleUnityPrefab);
        ParticleUnityLine b = go.GetComponent<ParticleUnityLine>();
        b.transform.SetParent(particleAnchor);
        b.rb.transform.position = 2 * Vector3.right * (0.5f * numParticles - ParticleUnitys.Count);
        b.myIndex = ParticleUnitys.Count;//index the particle
        ParticleUnitys.Add(b);

        if (ParticleUnitys.Count < numParticles)
        {
            InstantiateParticleUnitys();
        } 
    }
    public List<Vector3> ForceGetter()
    {
            
        List<Vector3> forces;
        Vector3 pos1, pos2;
        Vector3 forceDirection;

        forces = new List<Vector3>();

        for (int i = 0; i < ParticleUnitys.Count - 1; i++)
        {
            pos1 = ParticleUnitys[i].rb.transform.position;
            pos2 = ParticleUnitys[i + 1].rb.transform.position;
            forceDirection = pos1 - pos2;
            forceDirection = forceDirection - forceDirection.normalized * equilibriumSpringLength;
            forces.Add(-springConstant * forceDirection);
        }
        return forces;
            

    }
}
