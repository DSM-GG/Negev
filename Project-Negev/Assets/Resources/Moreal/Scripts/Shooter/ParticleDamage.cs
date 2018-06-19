using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
	private ParticleSystem particleLauncher = null;

	[SerializeField] private int particleDamage = 0;
	
	// Use this for initialization
	void Start ()
	{
		particleLauncher = gameObject.GetComponent<ParticleSystem>();
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
			
			// TODO :: Damage Player Method
			
			// gameObject.GetComponent<Damage>()..
			
			p.remainingLifetime = 0;
			
			enter[i] = p;
		}

		particleLauncher.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
	}
}
