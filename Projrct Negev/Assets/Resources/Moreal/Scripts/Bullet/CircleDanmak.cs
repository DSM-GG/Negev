using System.Collections;
using System.Collections.Generic;
using Resources.Moreal.Scripts.Spells;
using UnityEngine;

public class CircleDanmak : Spell
{
	// Shooting Coroutine
	protected override IEnumerator ActionSpell()
	{
		while (true)
		{
			if (isActive)
			{
				for (int i = 0; i < bulletCount; ++i)
				{
					
					GameObject obj = Instantiate(bulletPrefab, gameObject.transform.position,
						transform.rotation); // Quaternion.identity 은 돌지 않는 객체인 것이다.

					obj.GetComponent<Rigidbody>().AddForce(new Vector3(
						speed * Mathf.Cos(360f / bulletCount * i * Mathf.Deg2Rad), 0f,
						speed * Mathf.Sin(360f / bulletCount * i * Mathf.Deg2Rad)));
				}
			}

			yield return intervalTime;
		}
	}
}
