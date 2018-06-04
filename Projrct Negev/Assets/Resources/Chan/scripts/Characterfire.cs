using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterfire : MonoBehaviour {
    public GameObject NomalBulletPrefab = null;
    public GameObject HomingBulletPrefab = null;
    public float FireTime = 0.5f;

    bool Missile_Fire_State = true;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Z))
        {
            if (Missile_Fire_State)
            {
                Invoke("FireSpeedController", FireTime);
                Instantiate(NomalBulletPrefab, transform.position, transform.rotation);
                Missile_Fire_State = false;
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (Missile_Fire_State)
            {
                Invoke("FireSpeedController", FireTime);
                Instantiate(HomingBulletPrefab, transform.position, transform.rotation);
                Missile_Fire_State = false;
            }
        }
    }
    void FireSpeedController()
    {
        Missile_Fire_State = true;
    }
}
