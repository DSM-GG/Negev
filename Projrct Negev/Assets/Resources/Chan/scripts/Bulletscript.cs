using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour {
    public float MissileSpeed = 30f;
    public float DestroyMissileZpos = 18f;

	// Use this for initialization
	void Start () {
        StartCoroutine("DeleteDelay",3);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0, 0, 1) * MissileSpeed * Time.deltaTime); 
	}

    IEnumerator DeleteDelay(int sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }
}
