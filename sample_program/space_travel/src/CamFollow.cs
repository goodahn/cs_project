using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float dist=10f;
	public float height=3f;
	public float damptrace=20f;
	public float speed;
	private TCPConnection myTCP;	
	private string serverMsg;	
	public string msgToServer;
	private string serverSays;

	public Rigidbody lazer;
	// for receiving data
	private float delta_x=0f;
	private float delta_y=0f;
	private float delta_z=0f;
	private float rota_x=0f;
	private float rota_y=0f;
	private float rota_z=0f;





	void Awake() {
		
		//add a copy of TCPConnection to this game object		
		//myTCP = gameObject.AddComponent<TCPConnection>();
	}

	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();

	/*	if (myTCP.socketReady == true) {
			serverSays = "";
			string[] splitString = serverSays.Split(new string[] {" "},StringSplitOptions.None);
			try{
			delta_x = float.Parse(splitString[0]);
			delta_y = float.Parse(splitString[1]);
			delta_z = float.Parse(splitString[2]);
			rota_x = float.Parse(splitString[3]);
			rota_y = float.Parse(splitString[4]);
			rota_z = float.Parse(splitString[5]);
			} catch (Exception e) {
			}
		}*/
		if (Input.GetMouseButtonDown(0)) {

			Rigidbody clone = (Rigidbody)Instantiate(lazer, target.position, transform.rotation);
			if(clone!=null) 
				clone.velocity = transform.TransformDirection (Vector3.forward * 10);

		}
	}

/*	void SocketResponse() {
		string serverSays = "";
		if (serverSays != "") {
			Debug.Log("[SERVER]" + serverSays);	
		}
	}*/

	void OnGUI() {	
		//if connection has not been made, display button to connect

	/*	if (myTCP.socketReady == false) {
			if (GUILayout.Button ("Connect")) {
				//try to connect
				Debug.Log("Attempting to connect..");
				//myTCP.setupSocket();
			}
		}
		//once connection has been made, display editable text field with a button to send that string to the server (see function below)
		if (myTCP.socketReady == true) {
			if (GUILayout.Button ("Connected!")) {
				Debug.Log("connected!");
			}
		}*/
	}


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
			Debug.Log(" z is pressed");
		}
		if (Input.GetKey (KeyCode.E)) {
			z_rotation += 1;
		}
		if (Input.GetKey (KeyCode.C)) {
			z_rotation +=-1;
		}
		target.transform.Translate (new Vector3 (moveHorizontal, z_position, moveVertical) * speed * Time.deltaTime);
		target.transform.Rotate (new Vector3 (-Input.GetAxis("Mouse Y"), Input.GetAxis ("Mouse X"), z_rotation) );
		transform.Translate (new Vector3 (moveHorizontal, z_position, moveVertical) * speed * Time.deltaTime);
		transform.Rotate (new Vector3 (-Input.GetAxis("Mouse Y"), Input.GetAxis ("Mouse X"), z_rotation) );
		//target.transform.Translate (new Vector3 (delta_x*0.1, delta_z*0.1f, delta_y*0.1f));
		//target.transform.Rotate (new Vector3 (rota_x, rota_y, rota_z));
		//transform.Translate (new Vector3 (delta_x*0.1f, delta_z*0.1f, delta_y*0.1f));
		//transform.Rotate (new Vector3 (rota_x, rota_y, rota_z));
	}
}
