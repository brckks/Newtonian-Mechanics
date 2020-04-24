using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class AddForce : MonoBehaviour {

	public Vector3 forceVector;
	private PhysicsEngine physicsEngine;

	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent <PhysicsEngine> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		physicsEngine.AddForce (forceVector);
	}
}
