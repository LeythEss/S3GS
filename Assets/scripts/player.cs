using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb2d;
    Animator anim;
    public Collider2D groundCheck;
    bool grounded = true;
    int numberOfJump = 1;
    public LayerMask groundLayer;
    float x;
    public bool facingRight = true;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");

        Vector2 targetVelocity = new Vector2(x * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime);

      
    }
   
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || numberOfJump > 1))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            numberOfJump--;


        }
        if (grounded)
            numberOfJump = 2;
        grounded = groundCheck.IsTouchingLayers(groundLayer);

        if (x > 0 && facingRight == false)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight == true)
        {
            // ... flip the player.
            Flip();
        }
        if(x !=0)
            anim.SetBool("isWalking", true);
        if(x == 0)
            anim.SetBool("isWalking", false);
        look();
       
        
        
           
    }
    void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }

    void look()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("lookUp", true);
            anim.SetBool("lookDown", false);
            anim.SetBool("lookFront", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("lookDown", true);
            anim.SetBool("lookUp", false);
            anim.SetBool("lookFront", false);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) && facingRight == true) || (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight == false))
        {
            anim.SetBool("lookFront", true);
            anim.SetBool("lookUp", false);
            anim.SetBool("lookDown", false);
        }

        
    }
    bool faceright()
    {
        return facingRight;
    }

}
