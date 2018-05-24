using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {
    public static Transform EnemyPosition;
    bool Missile_Fire_State = true;
    public GameObject HomingBullet = null;
    public float FireTime = 0.5f;

    // Use this for initialization
    void Start () {
        EnemyPosition = GameObject.Find("Enemy").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.X))
        {
            if (Missile_Fire_State)
            {
                Invoke("FireSpeedController", FireTime);
                Instantiate(HomingBullet, transform.position, transform.rotation);
                Missile_Fire_State = false;
            }
        }
	}
    void FireSpeedController()
    {
        Missile_Fire_State = true;
    }
}
