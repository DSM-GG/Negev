using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Die : MonoBehaviour {

    public float life_time = 5f;

    static bool used = false;
    bool isMaster = false;

    float start_time;

	// Use this for initialization
	void Start () {
        if (!used)
        {
            used = true;
            isMaster = true;
        }

        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(isMaster)
            Debug.Log(Time.time - start_time);

        if (Time.time - start_time > life_time)
            Destroy(gameObject);
	}
}
