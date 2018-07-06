using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public static Transform EnemyPosition;
    bool Missile_Fire_State = true;
    public float FireTime = 0.5f;
    public float MissileSpeed = 30f;
    public float DestroyMissileZpos = 18f;
    public GameObject Enemy = null;

    // Use this for initialization
    protected void Start()
    {
        StartCoroutine("DeleteDelay", 3);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * MissileSpeed * Time.deltaTime);
    }

    IEnumerator DeleteDelay(int sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }


    void FireSpeedController()
    {
        Missile_Fire_State = true;
    }
}