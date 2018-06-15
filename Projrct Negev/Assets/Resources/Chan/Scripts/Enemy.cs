using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float Enemyhp = 1f;
    float deal = 0.25f;

	// Use this for initialization
	void Start () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Enemyhp -= deal;
            Debug.Log("적의 체력 :" + Enemyhp);
        }
    }

    // Update is called once per frame
    void Update () {
		if (Enemyhp == 0)
        {
            StageManager.killedenemy++;
            Destroy(this);
        }
	}
}
