﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homingscirpt : Bulletscript {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        Homingtarget();
        if (Enemy != null)
        {
            Vector3 dir = Enemy.transform.position - transform.position;
            this.transform.Translate(dir.normalized * MissileSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(0, 0, 1) * MissileSpeed * Time.deltaTime);
        }
    }
    void Homingtarget()
    {
        EnemyPosition = GameObject.Find("Enemy").transform;
    }
}
