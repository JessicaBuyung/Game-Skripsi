 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //how fast the player can move
    public float topSpeed = 10f;

    //tell the sprite which direction it is pointing
    bool facingRight = true;

    //get reference to animator
    Animator anim;

    //not grounded
    bool grounded = false;

    // transform at player foot to see of he is touching the ground
    public Transform groundCheck;

    //how big the circle is going to be when we check distance to the ground
    float groundRadius = 0.2f;

    //force of the jump
    public float jumpForce = 700f;

    //what layer is concidered ground
    public LayerMask whatIsGround;

   

    void Start()
    {
       
        anim = GetComponent<Animator>();

        //sanity check to make sure player is not dead
        anim.SetBool("isDead", false)
;    }

    //physics in fixed update
    void FixedUpdate()
    {
        //true of false did the ground transform hit the whatIsGround with the groundRadius
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //tell the animator that we are grounded
        anim.SetBool("Ground", grounded);

        //get how fast we are moving up or down form the rigidbody
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        //get move direction
        float move = SimpleInput.GetAxis("Horizontal");

        // add velocity to the rigidbody in the move direction* ourspeed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        //if we're face the negtive direction and not faceing right , flip
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //not on the ground
            anim.SetBool("Ground", false);

            //add jump force to the y axsis of the rigidbody
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    public void Jump()
    {
        //not on the ground
        anim.SetBool("Ground", false);

        //add jump force to the y axsis of the rigidbody
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }


    void Flip()
    {
        //saying we are facing the oposite direction
        facingRight = !facingRight;

        //get the local scale
        Vector3 theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }

}
