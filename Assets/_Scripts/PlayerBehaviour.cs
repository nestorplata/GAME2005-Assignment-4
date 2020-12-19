using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public int fireRate;


    public BulletManager bulletManager;



    void start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var tempBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            tempBullet.GetComponent<BulletBehaviour2>().direction = bulletSpawn.forward;
            //tempBullet.transform.SetParent(bulletManager.gameObject.transform);
        }


       
    }

  
}
