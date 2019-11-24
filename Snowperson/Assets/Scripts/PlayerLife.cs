using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{


    [SerializeField]
    public float playerLife = 100f;
    public bool isDrainingLife = false;
    public float tickRate;
    public float damage;
    private float time;
    public bool hasCoat = false;
    public float coatDurabilty = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coatDurabilty <= 0){
            hasCoat = false;
            coatDurabilty = 100f;
        }

        if(isDrainingLife){
            GetComponentInChildren<TrailRenderer>().emitting = true;
            time += Time.deltaTime;
            if(time > tickRate){
                if(hasCoat){
                    playerLife -= (damage - 3);
                    coatDurabilty -= 10;
                    time = 0f; 
                }else{
                    playerLife -= damage;
                    time = 0f;
                }
            }
            //drain life
            Debug.Log("derretendo");
        }else{
            time = 0f;
            GetComponentInChildren<TrailRenderer>().emitting = false;

        }
    }
}
