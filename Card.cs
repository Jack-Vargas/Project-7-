using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject Picker;
    public CardToutcher script;

    private void Start()
    {
        Picker = GameObject.FindGameObjectWithTag("picker");
        script = Picker.GetComponent<CardToutcher>();
    }

    private void Update()
    {
        
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {
        
    }

    private void OnMouseDown()
    {
        if (Picker.transform.childCount < 1)
        {
            gameObject.transform.parent = Picker.transform;
            gameObject.transform.position = Picker.transform.position + new Vector3 (0,0,10);
            script.PickUp();
        }           
    }
}
