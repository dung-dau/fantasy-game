using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed;
	public bool isGrounded;
	public float jumpForce;
	float vy;
    float vx;
	bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	Move();
            if(Input.GetButtonDown ("Jump")){
                rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            }
        
    }

    void Move()
    {
    	float x = Input.GetAxisRaw("Horizontal");
    	float moveBy = x * speed;
        vx = rb.velocity.x;

        if(vx > 0)
        {
            facingRight = true;
        }
        else if(vx < 0)
        {
            facingRight = false;
        }
    	rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void LateUpdate()
    {
        // get the current scale
        Vector3 localScale = transform.localScale;

        if (vx < 0) // moving right so face right
        {
            facingRight = true;
        } else if (vx > 0) { // moving left so face left
            facingRight = false;
        }

        // check to see if scale x is right for the player
        // if not, multiple by -1 which is an easy way to flip a sprite
        if (((facingRight) && (localScale.x<0)) || ((!facingRight) && (localScale.x>0))) {
            localScale.x *= -1;
        }   

        // update the scale
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }


}
