using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 newPos;
    public bool buttPress = false;

	public float speed;
	public Vector2 movement;
	private Vector2 animaMov;
	private Pushing push;
	private bool isBox;
	private Animator animator;

    public class Grid {

        public int height;
        public int size;

        public Grid (int _height, int _size) {
            height = _height;
            size = _size;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    	push = GameObject.FindWithTag("Block").GetComponent<Pushing>();
    	animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;

    	animator.SetFloat("HorizontalMove", animaMov.x);
    	animator.SetFloat("VerticalMove", animaMov.y);
        animator.SetBool("ButtonPressed", buttPress);

<<<<<<< Updated upstream
    	animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
    	animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    	animator.SetFloat("Speed", animaMov.sqrMagnitude);
=======
    	//animator.SetFloat("Veloc", animaMov.sqrMagnitude);
>>>>>>> Stashed changes

    }

    void FixedUpdate()
    {
    	//moving player
        if(Input.GetKeyDown(KeyCode.RightArrow) && movement.x >= -0.1)
        {
            if(transform.position.x <= (startPos.x + 14)) transform.position += new Vector3(1.0f ,0,0); 
            animaMov.x = Input.GetAxisRaw("Horizontal");
            animaMov.y = Input.GetAxisRaw("Vertical");
            buttPress = true;
        } 
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && movement.x <= 0.1)
        {
            if(transform.position.x > startPos.x) transform.position -= new Vector3(1.0f,0,0); 
            animaMov.x = Input.GetAxisRaw("Horizontal");
            animaMov.y = Input.GetAxisRaw("Vertical");
            buttPress = true;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && movement.y >= -0.1)
        {
        	if(transform.position.y <= startPos.y) transform.position += new Vector3(0,1.0f,0); 
            animaMov.x = Input.GetAxisRaw("Horizontal");
            animaMov.y = Input.GetAxisRaw("Vertical");
            buttPress = true;
        } 
        else if((Input.GetKeyDown(KeyCode.DownArrow)) && (movement.y <= 0.1))
        {
        	if(transform.position.y > (startPos.y - 7)) transform.position -= new Vector3(0,1.0f,0);
            animaMov.x = Input.GetAxisRaw("Horizontal");
            animaMov.y = Input.GetAxisRaw("Vertical");
            buttPress = true;
        } // if player is colliding with wall or box, he does not move. 
        else if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && isBox)
		{
			Debug.Log("is Box!!");
            push.movingBoxes(movement);
			isBox = false;
		}

        if( (Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)) ) 
        {
            buttPress = false;
        }
    }

	private void OnCollisionEnter2D (Collision2D other)
    {
    	Debug.Log("hi");
    	if(other.gameObject.tag == "Block")
    	{
    		isBox = true;
    	}
    	foreach(ContactPoint2D hitPos in other.contacts)
    	{
    		Debug.Log(hitPos.normal);
    		movement.y =hitPos.normal.y;
    		movement.x = hitPos.normal.x;
    	}

    }

    private void OnCollisionExit2D (Collision2D other) {
    	isBox = false;
    	movement = new Vector2 (0,0);
    }

}
