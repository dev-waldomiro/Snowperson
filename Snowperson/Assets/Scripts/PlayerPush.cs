using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{

	public Vector2 mov;
	public bool isPushing = false;

    void Update()
    {

        if(isPushing) 
        {
        	if(mov.x != 0) transform.position += new Vector3(0.5f, 0, 0);
        	else if (mov.y != 0) transform.position += new Vector3(0, 0.5f, 0);
        	isPushing = !isPushing;
    	}
    }

    void onTriggerEnter2D (Collider2D col)
    {
    	Debug.Log("hi");
    	if(col.gameObject.tag == "Block")
    	{
    		Debug.Log("h0p");
    		//isColliding = true;
    		//pp.mov = movement;
    	}

    }

}
