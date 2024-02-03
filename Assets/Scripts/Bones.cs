using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bones : MonoBehaviour
{
    //Make a line of virtices that interact with nearest neighbors dynamically through a spring-like force

    public int xSize = 10;
    //public int zSize = 10;
    public float vertRad = 0.1f;
    public float equilibriumSpringLength = 1.0f;
    public float springConstant = 30f;
    public float dotmass = 1.0f;

    private Vector3[] vertices;
    private Vector3[] vels;

    private void Awake()
    {
        //vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        //for (int i = 0, z = 0; z <= zSize; z++)
        //{
        //vertices[i] = new Vector3(x, 0, z);
        //for (int x = 0; x <= xSize; x++, i++)
        //{
        //vertices[i] = new Vector3(x, z);
        //}
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        vertices = new Vector3[(xSize + 1)];
        vels = new Vector3[(xSize + 1)];
        for (int x = 0; x <= xSize; x++)
        {
            vertices[x] = new Vector3(x, 0, 0);
            vels[x] = new Vector3(0, 0, 0);
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {    
        float kappa;
        Vector3 vel, pos, dpos0;
        Vector3 accelerationL, accelerationR;

        kappa = springConstant / dotmass;

        vertices[0] = 0.2f * Mathf.Sin(1.0f*2.0f * Mathf.PI * Time.time)*Vector3.right;

        for (int i = 0; i < vertices.Length - 2; i++)
        {
            pos = vertices[i + 1];
            vel = vels[i + 1];

            dpos0 = pos - vertices[i];
            //Debug.Log("dpos0" + dpos0);
            accelerationL = -kappa * (dpos0.magnitude - equilibriumSpringLength) * dpos0.normalized;
            //Debug.Log("eq vect" + dpos0.normalized);
            dpos0 = vertices[i + 2] - pos;
            //Debug.Log("dpos0" + dpos0);
            //Debug.Log("equilibriumSpringLength" + equilibriumSpringLength);
            accelerationR = -kappa * (dpos0.magnitude - equilibriumSpringLength )* dpos0.normalized;
            
            pos += Time.deltaTime * vel;
            vel += Time.deltaTime * (accelerationL - accelerationR);
 
            vertices[i + 1] = pos;
            vels[i + 1] = vel;

            //Debug.Log("pos" + pos);
            //Debug.Log("vel" + vel);
            //Debug.Log("accelerationR" + accelerationR);
            //Debug.Log("accelerationL" + accelerationL);
        }
        int iN = vertices.Length-1;
        pos = vertices[iN];
        vel = vels[iN];
        dpos0 = pos - vertices[iN-1];
        accelerationR = -kappa * (dpos0.magnitude - equilibriumSpringLength) * dpos0.normalized;
        //Debug.Log("norm" + dpos0.normalized);
        pos += Time.deltaTime * vel;
        vel += Time.deltaTime * (accelerationR);
        vertices[iN] = pos;
        vels[iN] = vel;

    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], vertRad);
        }
    }
}
