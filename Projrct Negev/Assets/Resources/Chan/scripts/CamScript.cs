using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public Vector3 pos;
    public float freeze_y;

	// Use this for initialization
	void Start () {
        pos = Camera.main.WorldToViewportPoint(transform.position);
        freeze_y = pos.y;
    }
	
	// Update is called once per frame
	void Update () {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f)
            pos.x = 0f;

        if (pos.x > 1f)
            pos.x = 1f;

        if (pos.y < freeze_y)
            pos.y = freeze_y;

        if (pos.y > freeze_y)
            pos.y = freeze_y;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
