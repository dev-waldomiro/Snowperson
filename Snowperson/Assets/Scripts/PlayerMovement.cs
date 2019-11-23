using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private bool facingRight;
	private bool facingUp;


	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	public Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
    	sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
   		movement.x = Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        Flip();
    }

    void Flip() 
    {
    	if (movement.x < 0)
    	{
    		facingRight = false;
    		transform.localRotation = Quaternion.Euler(0,90,0);
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
    }


}
