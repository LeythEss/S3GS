using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float smooth;
    public float speed;
    public float jumpForce;
    Rigidbody2D rb2d;
    Animator anim;
    public Collider2D groundCheck;
    bool grounded = true;
    int numberOfJump = 1;
    public LayerMask groundLayer;
    float x;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");

        Vector2 targetVelocity = new Vector2(x * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);

      
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

}
