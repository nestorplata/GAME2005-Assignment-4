using System.Collections;
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
    public float n_force;
    public float f_friction;
    public float c_friction;
    public bool bouncing =false;
    public bool top = true;
    public Vector3 direction;
    public Vector3 movement;
    public Vector3 Bauncing_value;



    public bool isColliding;
    public bool debug;
    public List<CubeBehaviour> contacts;

    private MeshFilter meshFilter;
    private Bounds bounds;
    private float limit;

 
    
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

        f_friction = normal * c_friction;

        //position
        transform.position += direction;

        if (isColliding == true && bouncing == false && top == true)
        {
 
            if (i < 4.0f)
            {
                speed = (speed * -1);
                i++;
            }
            else if (i >=4)
            {
                speed = 0;
                gravity = 0;
            }
            bouncing = true;
            top = false;
        }
        else if (bouncing == true && top == false)
        {
            bouncing = false;
        }
        else if (speed < 0.1)
        {
            top = true;
        }
        


        //velocity appliance over position
        direction = (Vector3.down) * speed * Time.deltaTime - i*(Vector3.up * f_friction * Time.deltaTime);
        //gravity appliance over velocity
        speed += gravity;








        //transform.position = direction;
        //direction = direction + (Vector3.down) * (speed * Time.deltaTime + (1/2)* gravity* (Time.deltaTime* Time.deltaTime));
        //movement =  * speed * Time.deltaTime;
        //speed += gravity;
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
