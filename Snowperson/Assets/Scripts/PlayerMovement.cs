using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private bool facingRight;
	private bool facingUp;
	private bool isColliding = false;


	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	public Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
    	//rb = GetComponent<Rigidbody2D>();
    	//prite = GetComponent<SpriteRenderer>();
    	// GameObject.FindWithTag("Block").GetComponent<PlayerPush>();
    }

    // Update is called once per frame
    void Update()
    {
   		movement.x = Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && !isColliding)
        {
        	transform.position += new Vector3(0.5f ,0,0); 
        } 
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && !isColliding)
        {
        	transform.position -= new Vector3(0.5f,0,0); 
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && !isColliding)
        {
        	transform.position += new Vector3(0,0.5f,0); 
        } 
        else if(Input.GetKeyDown(KeyCode.DownArrow) && !isColliding)
        {
        	transform.position -= new Vector3(0,0.5f,0);
        }
        else if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && isColliding)
        {
        	isColliding = !isColliding;
        }
    }
	
	    private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("asdfkhas");
			if(other.gameObject.tag == "heatSource"){
				//start HP draining
				Debug.Log("derretendo");
			}
    }

	// private void OnCollisionStay2D(Collision2D other) {
	// 	        Debug.Log("asdfkhas");
    //     if(other.gameObject.tag == "heatSource"){
    //         //start HP draining
    //         Debug.Log("derretendo");
	// }}

    // private void OnTriggerExit2D(Collider2D other) {
    //     Debug.Log("asdfkhas");

    //     if(other.gameObject.tag == "heatSource"){
    //         //stop HP draining
    //         Debug.Log("parou de derreter");
    //     }
    // }

}
