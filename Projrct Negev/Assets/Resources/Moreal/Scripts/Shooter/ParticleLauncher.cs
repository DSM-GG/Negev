using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{	
	public ParticleSystem particleLauncher;

	public List<ParticleCollisionEvent> collisionEvents;

	private float cnt = 0;
	
	[SerializeField]
	public int divCnt;

	// Use this for initialization
	void Start () 
	{
		particleLauncher = GetComponent<ParticleSystem>();

		collisionEvents = new List<ParticleCollisionEvent>();		
	}
	
	void FixedUpdate()
	{
//		shootOnce();
	}

	void shootOnce()
	{
		transform.rotation = toQuaternion(360.0f / divCnt * (cnt++));
		cnt %= divCnt;
		particleLauncher.Emit(1);
	}

	Quaternion toQuaternion(float _angle)
	{
		return Quaternion.AngleAxis(_angle, transform.position);
	}
	
	Vector3 toVector3(float _angle)
	{
		return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), 0, Mathf.Cos(_angle * Mathf.Deg2Rad));
	}

	Vector2 toVector2(float _angle)
	{
		return new Vector2();
	}
	

	private void OnParticleTrigger()
	{
		List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

		int entEnter = particleLauncher.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
		
		Component col = particleLauncher.trigger.GetCollider(0);
		GameObject gameObject = col.gameObject;

		for (int i = 0; i < entEnter; ++i)
		{ 
			ParticleSystem.Particle p = enter[i];
			
			if (gameObject.tag != "Bullet" && gameObject.tag != "Player")
				Debug.Log(p.remainingLifetime);
			
			p.remainingLifetime = 0;
			enter[i] = p;
		}
		
		particleLauncher.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
	}
}
