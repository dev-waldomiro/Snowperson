using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	public Vector2 movement;
	private Vector2 animaMov;
	private Pushing push;
	private bool isBox;
	public Animator animator;
    public PlayerLife playerLife;
    public ToggleTorch toggleTorch;



 // Start is called before the first frame update
    void Start()
    {
    	push = GameObject.FindWithTag("Block").GetComponent<Pushing>();
    	animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
                if(Input.GetKey(KeyCode.R)){
            Debug.Log("Escape");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    	animaMov.x = Input.GetAxisRaw("Horizontal");
    	animaMov.y = Input.GetAxisRaw("Vertical");

    	animator.SetFloat("EixoX", animaMov.x);
    	animator.SetFloat("EixoY", animaMov.y);
    	animator.SetFloat("Veloc", animaMov.sqrMagnitude);


    }

    void FixedUpdate()
    {
    	//moving player
        if(Input.GetKey(KeyCode.RightArrow) && movement.x >= -0.1)
        {
        	transform.position += new Vector3(0.5f, 0,0)*speed; 
        } 
        else if(Input.GetKey(KeyCode.LeftArrow) && movement.x <= 0.1)
        {
        	transform.position -= new Vector3(0.5f, 0,0)*speed; 
        }
        else if(Input.GetKey(KeyCode.UpArrow) && movement.y >= -0.1)
        {
        	transform.position += new Vector3(0,0.5f,0)*speed; 
        } 
        else if((Input.GetKey(KeyCode.DownArrow)) && (movement.y <= 0.1))
        {
        	transform.position -= new Vector3(0,0.5f,0)*speed;
        } // if player is colliding with wall or box, he does not move. 
        else if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && isBox)
		{
			Debug.Log("is Box!!");
			push.movingBoxes(movement);
			isBox = false;
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
    
	
	    private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("entrou");
			if(other.gameObject.tag == "heatSource"){
                toggleTorch.inHeatSource = true;
				playerLife.isDrainingLife = true;
				Debug.Log("derretendo");
			}
            if(other.gameObject.tag == "Coat"){
                playerLife.hasCoat = true;
                playerLife.coatDurability = 100f;
                Destroy(other.gameObject);
            }
    }



    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("saiu");
        if(other.gameObject.tag == "heatSource"){
            toggleTorch.inHeatSource = false;
            if(!toggleTorch.isLit){
            playerLife.isDrainingLife = false;
            Debug.Log("parou de derreter");
            }
        }

    }

}
