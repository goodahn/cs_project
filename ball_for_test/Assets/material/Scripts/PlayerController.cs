using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

   
    private Rigidbody rb;
    public float speed;
    private Vector3 mouse_p;
/*    void Update() //before rendering code
    {               // most of game code will go on
        
            mouse_p = new Vector3((((float)Input.mousePosition.x) - Screen.width / 2) * 0.05f, 0.0f, (Input.mousePosition.y * 0.05f - Screen.height / 2)) * 0.05f;
            rb.MovePosition(mouse_p + rb.position);
        
    }*/
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()  // just before perform any physics
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement*speed);
		transform.Translate (new Vector3 (moveHorizontal, 0, moveVertical) * speed * Time.deltaTime);
		transform.Rotate (new Vector3 (Input.GetAxis("Mouse Y"), Input.GetAxis ("Mouse X"), 0) );

    }

    
/*    void OnMouseDrag()
    {
        Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objP = Camera.main.ScreenToWorldPoint(mouseP);
        transform.position = objP;
        
    }*/
}
