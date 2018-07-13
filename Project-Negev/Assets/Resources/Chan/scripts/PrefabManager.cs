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
           //Debug.Log(Enemy.name);
        }
    }

    public GameObject GetEnemy(string enemy_name)
    {
        Debug.Log(enemy_name);
        GameObject enemy;
        EnemyList.TryGetValue(enemy_name, out enemy);

        return enemy;
    }
}
