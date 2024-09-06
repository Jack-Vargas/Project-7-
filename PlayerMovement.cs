using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float jump;
    public bool facingRight;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float horizontal;
    private float mvHor;

    private bool airOption;

    private float cyoteTime = 0.2f;
    private float cyoteTimeCount;

    private float jumpBuffer = 0.2f;
    private float jumpBufferCount;

    public float dashPower;
    public float dashDur;
    public float dashRate;
    public float clDwn;
    private bool isDashing;
    private bool dashAv;

 

    private void FixedUpdate()
    {
        if(isDashing == true)
        {
            return;
        }

        float moveHor = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector3 (moveHor, rb2d.velocity.y);

        Flip();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            dashAv = true;
            airOption = true;
            cyoteTimeCount = cyoteTime;
        }
        else
        {
            cyoteTimeCount -= Time.deltaTime;
        }


        if (isDashing == true)
        {
            return; // cuts the update method this frame
        }

        if (Input.GetKeyDown(KeyCode.V) && dashAv == true && clDwn < Time.time)
        {
            StartCoroutine(Dash());

            clDwn = Time.time + 1f / dashRate;
            dashAv = false;
        }

        horizontal = Input.GetAxis("Horizontal");

        //First Jump

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferCount = jumpBuffer;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        //actual jump
        if (jumpBufferCount > 0f && isDashing == false && cyoteTimeCount > 0)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, jump);

            jumpBufferCount = 0f;
        }

        if (Input.GetKeyUp(KeyCode.W) && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
            cyoteTimeCount = 0f;
        }

        //double jump
        if (Input.GetKeyDown(KeyCode.W) && !IsGrounded() && airOption == true && cyoteTimeCount < 0)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, jump);
            airOption = false;
        }

        
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, Ground);
    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public IEnumerator Dash()
    {
        isDashing = true;
        float origonalGrav = rb2d.gravityScale;
        rb2d.gravityScale = 0f;

        if(facingRight == true)
        {
            rb2d.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        }
        else
        {
            rb2d.velocity = new Vector2(transform.localScale.x * dashPower * -1, 0f);
        }

        yield return new WaitForSeconds(dashDur);
        rb2d.gravityScale = origonalGrav;
        isDashing = false;
    }
}
