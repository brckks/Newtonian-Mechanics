using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {
	public float mass = 1.0f;  // [kg]


	/// The velocity. [m s^-1] 
	public Vector3 velocity; // average velocity

	[Tooltip("[kg m s^-2]")]
	public Vector3 netForce;



	private List<Vector3> forceList = new List<Vector3>();

	// Use this for initialization
	void Start () {
		SetupThrustTrail ();

	}
		
	void FixedUpdate () {
		RenderTrails ();
		UpdatePosition ();
	}

	public void AddForce (Vector3 forceVector){
		forceList.Add (forceVector);
	}

	void UpdatePosition(){

		// Sum Forces And Clear the List
		netForce = Vector3.zero;

		foreach (Vector3 force in forceList) {
			netForce = netForce + force;
		}

		forceList = new List<Vector3> (); //clear the list

		//calculate position change due to net force
		Vector3 acceleration = netForce / mass;
		velocity += acceleration * Time.deltaTime; 
		//update position
		transform.position += velocity * Time.deltaTime;
	}

	//code for drawing lines
	public bool showTrails = true;

	//private List<Vector3> forceVectorList = new List<Vector3> (); 
	private LineRenderer lineRenderer;
	private int numberOfForces;

	void SetupThrustTrail () {
		//forceVectorList = GetComponent<PhysicsEngine> ().forceList;

		lineRenderer = gameObject.AddComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find ("Sprites/Default"));
		lineRenderer.SetWidth (0.2f, 0.2f);
		lineRenderer.useWorldSpace = false;

	}

	void RenderTrails () {
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceList.Count;
			lineRenderer.SetVertexCount (numberOfForces * 2);
			int i = 0;

			foreach (Vector3 forceVector in forceList) {
				lineRenderer.SetPosition (i, Vector3.zero);
				lineRenderer.SetPosition (i + 1, forceVector);
				i = i + 2;

			}
		} 
		else {
			lineRenderer.enabled = false;
		}
	}

}
