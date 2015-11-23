using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float dist=10f;
	public float height=3f;
	public float damptrace=20f;
	public float speed;
	
	// Update is called once per frame
	void LateUpdate () {

		float z_position = 0;
		float z_rotation = 0;
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		if( Input.GetKey (KeyCode.Q)) {
			z_position +=1;
		}
		if(Input.GetKey (KeyCode.Z)) {
			z_position +=-1;
		}
		if (Input.GetKey (KeyCode.E)) {
			z_rotation += 1;
		}
		if (Input.GetKey (KeyCode.C)) {
			z_rotation +=-1;
		}
		transform.Translate (new Vector3 (moveHorizontal, z_position, moveVertical) * speed * Time.deltaTime);
		transform.Rotate (new Vector3 (-Input.GetAxis("Mouse Y"), Input.GetAxis ("Mouse X"), z_rotation) );
	}
}
