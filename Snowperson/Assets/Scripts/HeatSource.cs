using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "heatSource"){
            CircleCollider2D collider = this.gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
            collider.radius = 1.216936f;
            collider.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("asdfkhas");
    //     if(other.gameObject.tag == "Player"){
    //         //start HP draining
    //         Debug.Log("derretendo");
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    //     Debug.Log("asdfkhas");

    //     if(other.gameObject.tag == "Player"){
    //         //stop HP draining
    //         Debug.Log("parou de derreter");
    //     }
    // }
}
