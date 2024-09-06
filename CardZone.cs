using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{

    public GameObject Picker;
    public CardToutcher script;

    private void Start()
    {
        Picker = GameObject.FindGameObjectWithTag("picker");
        script = Picker.GetComponent<CardToutcher>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D()
    {
        script.NearZone = gameObject;
    }
    
    private void OnTriggerStay2D()
    {
        if (transform.childCount < 1)
        {
            script.NearZone = gameObject;
        }  
    }



    private void OnTriggerExit2D() 
    { 
        script.NearZone = null;
    }
}
