using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 0.5f;
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            Time.timeScale = 1.0f;
        }
    }
}
