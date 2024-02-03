using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    float xpos, ypos;
    float theta;
    public int method = 3;

    // Start is called before the first frame update
    void Start()
    {
        //start drawing here
        xpos = 1.0f;
        ypos = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (method == 1)
        { //Draw 1: draw the circle using sin and cos
          // there is no approximation, but
          // here we need to compute sin and cos many times
            xpos = Mathf.Sin(Time.time);
            ypos = Mathf.Cos(Time.time);
        }
        else if (method == 2)
        {   //Draw 2: draw the circle using approximates of sin and cos for small angles
            // this could work when theta is very small compared to 1, but the errors grow
            // and the sphere flies off
            theta = Time.time;
            xpos += theta * (1.0f - theta * theta / 6.0f);//Two terms of Taylor expansion for sin
            ypos += (1 - 0.5f * theta * theta);
        }
        else
        {
            //Draw 3: draw the circle by iterating a differential equation
            // using an euler approximation
            // This works well and accumulates errors slowly
            // It requires only one multiplicataion
            // To derive the differential equations differentiate
            // equations in Draw 1 with respect to theta then substitute for the sin and cos
            xpos += ypos * Time.deltaTime;
            ypos += -xpos * Time.deltaTime;
        }
        transform.position = new Vector3(xpos, ypos, 0.0f);
    }
}
