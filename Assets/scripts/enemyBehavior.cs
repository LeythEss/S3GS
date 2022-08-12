using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public float walkspeed;
    Rigidbody2D rb2d;
    Animator anim;
    public bool facingRight = true;
    public float walkDelay = 5f;
    float WalkElapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkElapsedTime += Time.deltaTime;
        Vector2 targetVelocity = new Vector2(-walkspeed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime);
        if (WalkElapsedTime >= walkDelay)
        {
            WalkElapsedTime = 0;
            walkspeed = -walkspeed;
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
    public void triggering()
    {
        walkspeed = 0f;
        anim.SetBool("isWalking",false);
        anim.SetBool("isShooting",true);
        walkDelay = 100000000f;
    }

    public 
        void untrigger()
    {
        walkspeed = 5f;
        anim.SetBool("isWalking", true);
        anim.SetBool("isShooting", false);
    }

}
