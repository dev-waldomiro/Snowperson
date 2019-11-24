using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLineController : MonoBehaviour
{
    // Start is called before the first frame update
    private float distance = 0x3f3f3f;
    private float auxDist;
    Gradient grad = new Gradient();
    [SerializeField]
    public GameObject[] heatSources;
    public float maxDist, minDist;
    GameObject controller;
    void Start()
    {
        heatSources = GameObject.FindGameObjectsWithTag("heatSource");
        controller = GameObject.FindWithTag("Lines");
    }

    // Update is called once per frame
    void Update()
    {
        var color = controller.GetComponent<ParticleSystem>().main;
        var emission = controller.GetComponent<ParticleSystem>().emission;

        foreach (var heatSource in heatSources)
        {
            auxDist = Vector2.Distance((Vector2)this.gameObject.transform.position, (Vector2)heatSource.transform.position);
            Debug.Log(auxDist +  "  auxDist");
            if(auxDist > distance){
                distance = auxDist;
            }
            Debug.Log(distance +  "  distance");

        }

        if(distance > maxDist){
            Debug.Log("longe demais de heatsource");
            //frio
            color.startColor = new Color(0.047f, 0.882f, 1f);
            emission.enabled = true;
        }

        public void turnHot(){
            Debug.Log("perto de heatsource");
            color.startColor = new Color(1f, 0f, 0f);
            emission.enabled = true;
        }

        public void turnWarm(){
            Debug.Log("warm");
            emission.enabled = false;
        }

        // if(distance < maxDist && distance > minDist){
        //     Debug.Log("warm");
        //     emission.enabled = false;
        // }

        // if(distance < minDist){
        //     Debug.Log("perto de heatsource");
        //     color.startColor = new Color(1f, 0f, 0f);
        //     emission.enabled = true;
        // }


    }
}
