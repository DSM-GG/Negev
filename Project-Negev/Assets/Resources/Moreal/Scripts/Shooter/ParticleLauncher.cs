using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{	
	public ParticleSystem particleLauncher;

	public List<ParticleCollisionEvent> collisionEvents;

	private int cnt = 0;
	private float aditiveAngle = 0;

	[SerializeField] public int divCnt;

	[SerializeField] public float intervalAngle;

	[SerializeField] public float intervalTime;

	// Use this for initialization
	void Start () 
	{
		particleLauncher = GetComponent<ParticleSystem>();

		collisionEvents = new List<ParticleCollisionEvent>();

		StartCoroutine(Routine());
	}
	
	void shootOnce()
	{
//		float _angle = (360.0f / divCnt * (cnt++) + aditiveAngle) % 360;
//		transform.rotation = ToQuaternion(_angle);
		
		cnt %= divCnt;
//		particleLauncher.startRotation
//		particleLauncher.Emit(1);
	}

//	Quaternion ToQuaternion(float _angle)
//	{
//		return Quaternion.Euler(_angle);
//	}


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

	IEnumerator Routine()
	{
		while (true)
		{
			
			aditiveAngle = (aditiveAngle + intervalAngle) % 360.0f;
			ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleLauncher.particleCount];
			int particleCount = particleLauncher.GetParticles(particles);
			for (int i = 0; i < particleCount; ++i)
			{
				ParticleSystem.Particle p = particles[i];
				AffectParticle(ref p);
				particles[i] = p;
			}
			
			for (int i = 0; i < divCnt; ++i)
				shootOnce();
			
//			Debug.Log((aditiveAngle + intervalAngle) % 360.0f);
			yield return new WaitForSeconds(intervalTime);
		}
	}

	protected virtual void AffectParticle(ref ParticleSystem.Particle particle)
	{
		
	}
}