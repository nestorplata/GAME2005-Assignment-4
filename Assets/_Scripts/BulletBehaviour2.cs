using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BulletBehaviour2 : MonoBehaviour
{

    public float speed;
    public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (-direction) * speed * Time.deltaTime;
    }
}
