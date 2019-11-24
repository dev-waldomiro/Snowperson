using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{


    [SerializeField]
    public float playerLife = 100f;
    public float coatDurability = 100f;
    public bool isDrainingLife = false;
    public float tickRate;
    public float damage;
    private float time;
    public bool hasCoat = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coatDurability <= 0){
            hasCoat = false;
            coatDurability = 100f;
        }

        if(isDrainingLife){
            FindObjectOfType<AudioManager>().Play("morrendo");
            GetComponentInChildren<TrailRenderer>().emitting = true;
            time += Time.deltaTime;
            if(time > tickRate){
                if(hasCoat){
                    playerLife -= (damage - 3);
                    coatDurability -= 10;
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
