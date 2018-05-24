using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    Transform target;
    int count;
    float Movespeed = 10f;

	// Use this for initialization
	void Start () {
        target = Waypoint.points[0];
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = target.position - transform.position;
        transform.Translate((vec.normalized * Movespeed) * Time.deltaTime, Space.World);

        if(Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            NextWayPoint();
        }
    }

    void NextWayPoint()
    {
        if(count >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        count++;
        target = Waypoint.points[count];
    }
}
