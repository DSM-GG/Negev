using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public static Transform[] points;
    public static int count;
    
	// Use this for initialization
	void Awake () {
        points = new Transform[transform.childCount];
        count = transform.childCount;
        for(int i=0; i<transform.childCount; i++)
        {
            points[i] = transform.GetChild(i).transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
