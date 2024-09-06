using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class CardToutcher : MonoBehaviour
{
    public GameObject CardHeld;
    private bool holdCheck = false;
    public GameObject NearZone;

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, -1f);        

        if (CardHeld != null && holdCheck == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                PutDown();
            }
        }
    }

    public void PutDown()
    {
        CardHeld.transform.parent = null;
        if (NearZone != null && NearZone.transform.childCount < 1)
        {
            CardHeld.transform.parent = NearZone.transform;
            CardHeld.transform.position = NearZone.transform.position + new Vector3(0, 0, -1);
        }
        CardHeld = null;
        holdCheck = false;
        NearZone = null;
    }

    public void PickUp()
    {
        CardHeld = gameObject.transform.GetChild(0).gameObject;
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForEndOfFrame();
        holdCheck = true;
    }
}
