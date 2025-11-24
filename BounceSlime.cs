using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSlime : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float bounceForce;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.gameObject);
    }

    public void Bounce(GameObject other)
    {
        rb2d = other.GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * bounceForce);
    }
}
