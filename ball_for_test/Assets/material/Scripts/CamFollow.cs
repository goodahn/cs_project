using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float dist=10f;
	public float height=3f;
	public float damptrace=20f;
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Lerp (transform.position
		                                  , target.position - (target.forward * dist) + Vector3.up * height
		                                  , Time.deltaTime * damptrace);
		transform.LookAt (target.position);
	}
}
