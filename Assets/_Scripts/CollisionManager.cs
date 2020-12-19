using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionManager : MonoBehaviour
{
    public CubeBehaviour[] actors;
    public BulletBehaviour2[] directors;

    private static Vector3[] sides;

    // Start is called before the first frame update
    void Start()
    {
        actors = FindObjectsOfType<CubeBehaviour>();

        sides = new Vector3[]
        {
            Vector3.left, Vector3.right,
            Vector3.down, Vector3.up,
            Vector3.back , Vector3.forward

        };
    }

    // Update is called once per frame
    void Update()
    {
        directors = FindObjectsOfType<BulletBehaviour2>();

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


        foreach (var sphere in directors)
        {
            foreach (var cube in actors)
            {
                if (cube.name != "Player")
                {
                    CheckSphereVsAABBs(sphere, cube);
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

    public static void CheckSphereVsAABBs(BulletBehaviour2 bullet, CubeBehaviour cube)
    {
        var x = Mathf.Max(cube.min.x, Mathf.Min(bullet.mCenter.x, cube.max.x));
        var y = Mathf.Max(cube.min.y, Mathf.Min(bullet.mCenter.y, cube.max.y));
        var z = Mathf.Max(cube.min.z, Mathf.Min(bullet.mCenter.z, cube.max.z));

        var distance = Mathf.Sqrt((x - bullet.mCenter.x) * (x - bullet.mCenter.x) +
                                  (y - bullet.mCenter.y) * (y - bullet.mCenter.y) +
                                  (z - bullet.mCenter.z) * (z - bullet.mCenter.z));
        if ((distance < bullet.radius) && (!bullet.isColliding))
        {
            float[] distances = {
                (cube.max.x - bullet.transform.position.x),
                (bullet.transform.position.x - cube.min.x),
                (cube.max.y - bullet.transform.position.y),
                (bullet.transform.position.y - cube.min.y),
                (cube.max.z - bullet.transform.position.z),
                (bullet.transform.position.z - cube.min.z)
            };

            float penetration = float.MaxValue;
            Vector3 side = Vector3.zero;

            for (int i = 0; i < 6; i++)
            {
                if (distances[i] < penetration)
                {
                    // determine the penetration distance
                    penetration = distances[i];
                    side = sides[i];
                }
            }

            bullet.penetration = penetration;
            bullet.collisionNormal = side;

            Reflect(bullet);
            
        }

    }
    private static void Reflect(BulletBehaviour2 bullet)
    {
        if ((bullet.collisionNormal == Vector3.forward) || (bullet.collisionNormal == Vector3.back))
        {
            bullet.direction = new Vector3(bullet.direction.x, bullet.direction.y, -bullet.direction.z);
        }
        else if ((bullet.collisionNormal == Vector3.right) || (bullet.collisionNormal == Vector3.left))
        {
            bullet.direction = new Vector3(-bullet.direction.x, bullet.direction.y, bullet.direction.z);
        }
        else if ((bullet.collisionNormal == Vector3.up) || (bullet.collisionNormal == Vector3.down))
        {
            bullet.direction = new Vector3(bullet.direction.x, -bullet.direction.y, bullet.direction.z);
        }
    }
}
