using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BulletBehaviour2 : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float range;
    public float radius;
    public bool debug;
    public bool isColliding;
    public Vector3 collisionNormal;
    public float penetration;

    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
        radius = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.5f;
        bulletManager = FindObjectOfType<BulletManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (-direction) * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, Vector3.zero) > range)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
    }
}
