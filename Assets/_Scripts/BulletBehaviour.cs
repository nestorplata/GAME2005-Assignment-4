using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float L_speed;
    public float mass;
    public float weight;
    public Vector3 direction;
    public float range;
    public float gravity = 0.01f;
    public bool destroy = false;

    public Vector3 mCenter;
    public Vector3 size;
    public float mRadious;

    public bool stop = false;

    public bool isColliding;
    public bool debug;
    public List<BulletBehaviour> contacts;


    // Start is called before the first frame update
    void Start()
    {
        debug = false;

    }

    // Update is called once per frame
    void Update()
    {
        mCenter = transform.position;

        mRadious = 0.5f;

        _Move();
        _CheckBounds();

    }

    private void _Move()
    {
        transform.position += direction;
        direction = (Vector3.down) * speed * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (/*Vector3.Distance(transform.position, Vector3.zero) > range ||*/ destroy == true)
        {
            Destroy(gameObject);
        }

    }
}
