using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing1 : MonoBehaviour {
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;



    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveToTarget()
    {
        accelaration = 0.1f;
        velocity = (velocity + accelaration * Time.deltaTime);
        target = GameObject.Find("Enemy").transform;
        direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= 100.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity), transform.position.z + (direction.z * velocity));
        }
    }
}
