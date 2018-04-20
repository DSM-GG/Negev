using UnityEngine;
using System.Collections;

public class Bullet_Hell : MonoBehaviour {

    public float speed;
    public int bullet_count;

    public GameObject bullet = null;

    public WaitForSeconds intervalTime;

    private void Awake()
    {
        intervalTime = new WaitForSeconds(1.0f / bullet_count);
    }

    private void Start()
    {
        StartCoroutine(HurricaneSpell());
    }

    IEnumerator CircleSpell()
    {
        while (true)
        {
            for (int i = 0; i < bullet_count; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position, transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.
                
                //Debug.Log("Cos : " + Mathf.Cos(360 * Mathf.Deg2Rad * i / bullet_count));
                
                obj.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Mathf.Cos(360 / bullet_count * i * Mathf.Deg2Rad), 0f, speed * Mathf.Sin(360 / bullet_count * i * Mathf.Deg2Rad)));
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator HurricaneSpell()
    {
        while(true)
        {
            for (int i = 0; i < bullet_count; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position, transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

                obj.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Mathf.Cos(360 / bullet_count * i * Mathf.Deg2Rad), 0f, speed * Mathf.Sin(360 / bullet_count * i * Mathf.Deg2Rad)));

                yield return intervalTime;
            }
        }
    }

    IEnumerator OtherHurricaneSpell()
    {
        uint interval = 0;
        while (true)
        {
            interval = interval + 7 % 180;

            for (int i = 0; i < bullet_count; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position, transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

                obj.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Mathf.Cos((360 / bullet_count * i + interval) * Mathf.Deg2Rad), 0f, speed * Mathf.Sin((360 / bullet_count * i + interval) * Mathf.Deg2Rad)));

                yield return intervalTime;
            }
        }
    }
}
