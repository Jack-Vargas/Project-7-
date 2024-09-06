using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public Rigidbody2D rb2d;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb2d.gravityScale = rb2d.gravityScale * -1;
            transform.Rotate(180f, 0f, 0f);
        }
    }
}
