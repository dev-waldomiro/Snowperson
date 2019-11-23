using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ToggleTorch : MonoBehaviour
{

    public GameObject torch;
    public bool isLit = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            if(isLit == true){
                torch.GetComponent<Light2D>().enabled = false;
                torch.GetComponent<ParticleSystem>().Stop();
                isLit = false;
                Debug.Log("apagou");
            }else{
                torch.GetComponent<Light2D>().enabled = true;
                torch.GetComponent<ParticleSystem>().Play();
                isLit = true;
                Debug.Log("acendeu");
            }
        }
        if(isLit)
            torch.GetComponent<Light2D>().color = new Color(1, Random.Range(0.666f, 0.847f), 0.466f);
    }
}
