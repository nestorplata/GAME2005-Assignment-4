﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;


[System.Serializable]
public class CubeBehaviour : MonoBehaviour
{

    public Vector3 size;
    public Vector3 max;
    public Vector3 min;

    public float i =1.0f;
    public float speed;
    public float mass;
    public float weight;
    public float normal;
    public float gravity;
    //public float time;
    //public float n_force;
    public float f_friction;
    public float c_friction;
    public Vector3 friction;
    public bool bouncing;
    public bool top;
    public bool going_up;
    public bool stop = false;
    public Vector3 direction;
    //public Vector3 movement;
    //public Vector3 Bauncing_value;



    public bool isColliding;
    public bool debug;
    public List<CubeBehaviour> contacts;

    private MeshFilter meshFilter;
    private Bounds bounds;
    //private float limit;

 
    
    // Start is called before the first frame update
    void Start()
    {
        debug = false;
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }

    void FixedUpdate()

    {

        //limit =;
        weight = mass * gravity;
        normal = -weight;

        f_friction = -normal * c_friction;

        //position
        transform.position += direction;
        

        //bouncing
        if (speed < 0.1f && speed > -0.1f)
        {
            top = true;
            going_up = false;
        }
        else
        {
            top = false;
        }
        if (isColliding == true && top == true)
        {
            stop = true;
        }



        if (isColliding == true && top == false)
        {
            bouncing = true;
        }
        else
        {
            bouncing = false;
        }


 

        if (bouncing == true && going_up == false)
        {
                speed = (speed * -1);
            friction = friction + (Vector3.up * f_friction * Time.deltaTime);

            bouncing = false;
            going_up = true;
        }


        //movement
        if (stop == true)
        {
            speed = 0;
            direction = (Vector3.down) * speed * Time.deltaTime;

        }
        else if (isColliding == true || top ==false)
        {

            direction = (Vector3.down) * speed * Time.deltaTime - friction;
            speed += gravity;
        }
        else
        {

            direction = (Vector3.down) * speed * Time.deltaTime;
            speed += gravity;
        }

            //gravity appliance over velocity


    }


    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawWireCube(transform.position, Vector3.Scale(new Vector3(1.0f, 1.0f, 1.0f), transform.localScale));
        }
    }
}
