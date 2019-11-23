using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private bool facingRight;
	private bool facingUp;
	private bool isColliding = false;
	private PlayerPush pp;


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

   /* void Flip() 
    {
    	if (movement.x < 0)
    	{
    		facingRight = false;
    		transform.localRotation = Quaternion.Euler(0,0,0);
    	}
    	else if (movement.x > 0)
    	{
    		facingRight = true;
    		transform.localRotation = Quaternion.Euler(0,0,0);
    	}
    	
    	if(movement.y < 0)
    	{
    		facingUp = false;
    		transform.localRotation = Quaternion.Euler(0,90,0);
    	}
    	else if (movement.y > 0)
    	{
    		facingUp = true;
    		transform.localRotation = Quaternion.Euler(0,270,0);
    	}
    } **/

	private void onCollisionEnter2D (Collider2D other)
    {
    	Debug.Log("hi");
    	if(other.gameObject.tag == "Block")
    	{
    		Debug.Log("h0p");
    		isColliding = true;
    		pp.mov = movement;
    		pp.isPushing = isColliding;
    	}

    }

}
