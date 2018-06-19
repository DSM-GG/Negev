using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using UnityEngine;

public class AimingParticle : MonoBehaviour
{

	[SerializeField] private GameObject player;

//	private static Vector3 vec = new Vector3(-1, 0, -1);
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(player.transform);
		transform.rotation = Quaternion.LookRotation((player.transform.position - transform.position));
	}
}
