using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{

	public bool isPushed;
	public Vector2 movePos;
	public Rigidbody2D rb;
    // Start is called before the first frame update
	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}
    // Update is called once per frame
    void Update()
    {

    }

    public void movingBoxes (Vector2 movement) {
    		if(movement.y > 0.5){
    			transform.position -= new Vector3(0,1f,0); 
    		} else if (movement.y < -0.5) {
    			transform.position += new Vector3(0,1f,0);
    		} else if (movement.x > 0.5) {
    			transform.position -= new Vector3(1f ,0,0);
    		} else if (movement.x < -0.5) {
    			transform.position += new Vector3(1f,0,0);
    		} 	
    }

}
