using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Instance : MonoBehaviour {

    public float life_time = 5f;

    float start_time;

	// Use this for initialization
	void Start () {
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - start_time > life_time) {
			Destroy(gameObject);
		}
	}
}
