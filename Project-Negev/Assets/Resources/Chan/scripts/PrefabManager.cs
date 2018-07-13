using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {
    Dictionary<string, GameObject> EnemyList = new Dictionary<string, GameObject>();
	// Use this for initialization
	void Awake () {
        GameObject[] objects = Resources.LoadAll<GameObject>("Chan\\Prefabs");
        foreach(GameObject Enemy in objects)
        {
           EnemyList.Add(Enemy.name, Enemy);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
