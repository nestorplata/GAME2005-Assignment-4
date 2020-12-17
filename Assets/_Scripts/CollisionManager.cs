using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionManager : MonoBehaviour
{
    public CubeBehaviour[] actors;
    public BulletBehaviour[] directors;

    // Start is called before the first frame update
    void Start()
    {
        actors = FindObjectsOfType<CubeBehaviour>();
        directors = FindObjectsOfType<BulletBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < directors.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i != j)
                {
                    CheckSphereVsAABBs(directors[i], actors[j]);
                }
            }
        }


        for (int i = 0; i < actors.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i != j)
                {
                    CheckAABBs(actors[i], actors[j]);
                }
            }
        }

    }

    public static void CheckAABBs(CubeBehaviour a, CubeBehaviour b)
    {
        if ((a.min.x <= b.max.x && a.max.x >= b.min.x) &&
            (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
            (a.min.z <= b.max.z && a.max.z >= b.min.z))
        {
            if (!a.contacts.Contains(b))
            {
                a.contacts.Add(b);
                a.isColliding = true;
            }
        }
        else
        {
            if (a.contacts.Contains(b))
            {
                a.contacts.Remove(b);
                a.isColliding = false;
            }

        }
    }

    public static void CheckSphereVsAABBs(BulletBehaviour bullet, CubeBehaviour cube)
    {
        var x = Mathf.Max(cube.min.x, Mathf.Min(bullet.mCenter.x, cube.max.x));
        var y = Mathf.Max(cube.min.y, Mathf.Min(bullet.mCenter.y, cube.max.y));
        var z = Mathf.Max(cube.min.z, Mathf.Min(bullet.mCenter.z, cube.max.z));

        var distance = Mathf.Sqrt((x - bullet.mCenter.x) * (x - bullet.mCenter.x) +
                                  (y - bullet.mCenter.y) * (y - bullet.mCenter.y) +
                                  (z - bullet.mCenter.z) * (z - bullet.mCenter.z));
        if (distance < bullet.mRadious == true)
        {
            bullet.isColliding = true;
            cube.isColliding = true;
        }
        else
        {
            bullet.isColliding = false;
            cube.isColliding = false;
        }

    }

}
