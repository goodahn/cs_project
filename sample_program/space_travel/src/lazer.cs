using UnityEngine;
using System.Collections;

public class lazer : MonoBehaviour {
	public Transform shooter;
	private bool clone;
	// Use this for initialization
	void Start () {
		if (shooter.position == transform.position) {
			clone=true;
		}
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "lazer")
		{
			
		}
		if(col.gameObject.name == "Sun")
		{
			
		}
		Destroy (col.gameObject);
	}


	// Update is called once per frame
	void Update () {
		Vector3 tmp = shooter.position - transform.position;
		if (Vector3.Dot (tmp, tmp) > 300) {
			if( clone == true)
				Destroy(gameObject);
		}
	}


}
