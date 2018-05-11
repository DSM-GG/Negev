using UnityEngine;
using System.Collections;

public class Bullet_Hell : MonoBehaviour {

    public float speed;  // Bullet Shooting Speed
    public int bulletCount;  // Count of Bullet per a second

    public GameObject bullet = null;  // Bullet Prefab

    public enum BulletType
    {
        CircleSpell = 0,
        HurricaneSpell = 1,
    };  
    
    public BulletType bulletType;  // Coroutine Self 
    
    
    private WaitForSeconds hurricaneIntervalTime;  // Static Variable for HurricaneSpell Coroutine

    private WaitForSeconds circleIntervalTime;  // Static Variable for CircleSpell Coroutine
    
    // Unity Life Cycle
    private void Awake()
    {
        circleIntervalTime = new WaitForSeconds(1.0f / bulletCount);
        hurricaneIntervalTime = new WaitForSeconds(1.0f / bulletCount);
    }
//
//    protected delegate void onShootEvent;
//    protected event onShootEvent onShot;
    private void Start()
    {
        StartCoroutine(CircleSpell());
//        switch (bulletType)
//        {
//                case BulletType.CircleSpell:
//                    StartCoroutine(CircleSpell());
//                    break;
//                case BulletType.HurricaneSpell:
//                    StartCoroutine(HurricaneSpell());
//                    break;
//        }
    }
    
    private bool isActive = true;  
    
    // User Method
    public void TurnOnShooting()
    {
        isActive = true;
    }

    public void TurnOffShooting()
    {
        isActive = false;
    }
    
    // Shooting Coroutine
    IEnumerator CircleSpell()
    {
        while (true)
        {
            if (isActive)
            {
                for (int i = 0; i < bulletCount; ++i)
                {
                    GameObject obj = Instantiate(bullet, gameObject.transform.position,
                        transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

                    obj.GetComponent<Rigidbody>().AddForce(new Vector3(
                        speed * Mathf.Cos(360f / bulletCount * i * Mathf.Deg2Rad), 0f,
                        speed * Mathf.Sin(360f / bulletCount * i * Mathf.Deg2Rad)));
                }
            }

            yield return circleIntervalTime;
        }
    }

    IEnumerator HurricaneSpell()
    {
        while(true)
        {
            for (int i = 0; i < bulletCount; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position,
                    transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

                obj.GetComponent<Rigidbody>().AddForce(new Vector3(
                    speed * Mathf.Cos(360f / bulletCount * i * Mathf.Deg2Rad), 0f,
                    speed * Mathf.Sin(360f / bulletCount * i * Mathf.Deg2Rad)));

                yield return hurricaneIntervalTime;
            }
        }
    }

    IEnumerator SlowFastSlowSpell()
    {
        const int ONCE_BULLET_COUNT = 100;
        while (true)
        {
            for (int i = 0; i < ONCE_BULLET_COUNT; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position, transform.rotation);
                
                obj.GetComponent<Rigidbody>().AddForce(new Vector3(
                    Mathf.Cos(360f / ONCE_BULLET_COUNT * i * Mathf.Deg2Rad), 0f,
                    Mathf.Sin(360f / ONCE_BULLET_COUNT * i * Mathf.Deg2Rad)));
                
//                yield return cir
            }
        }
    }
    
    /*
    
    IEnumerator OtherHurricaneSpell()
    {
        uint interval = 0;
        while (true)
        {
            interval = interval + 7 % 180;

            for (int i = 0; i < bulletCount; ++i)
            {
                GameObject obj = Instantiate(bullet, gameObject.transform.position, transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

                obj.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Mathf.Cos((360 / bulletCount * i + interval) * Mathf.Deg2Rad), 0f, speed * Mathf.Sin((360 / bulletCount * i + interval) * Mathf.Deg2Rad)));

                yield return intervalTime;
            }
        }
    }
    
    */
}
