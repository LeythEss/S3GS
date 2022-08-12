using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public GameObject lazerstraightPrefab;
    public GameObject lazerUpDownPrefab;
    public GameObject lazerDiagPrefab;
    public GameObject lazerDiagRightPrefab;
    public GameObject lazerDiagDownPrefab;
    public GameObject lazerDiagDownRightPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public float bulletForce = 0.01f;
    float fireElapsedTime = 0;
    public float fireDelay = 0.2f;
    public GameObject _player;
    private player script;
    Animator anim;
    float vertForce;
   

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(wait());
        script = _player.GetComponent<player>();
        anim = GetComponent<Animator>();
        
    }
   
   

    // Update is called once per frame
    void Update()
    {
        
        fireElapsedTime += Time.deltaTime;

        if (fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            if (Input.GetMouseButton(0)&&(anim.GetBool("lookUp") == false && anim.GetBool("lookDown") == false))
                ShotStraight();
            if (Input.GetMouseButton(0) && (anim.GetBool("lookUp") == true || anim.GetBool("lookDown") == true))
            {
                if (anim.GetBool("isWalking") == false)
                    ShotVertical();
                else
                    ShotDiag();
            }
                
        }
    }
    void ShotStraight()
    {
        GameObject bullet = Instantiate(lazerstraightPrefab, firePoint.position, firePoint.rotation);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

       
        if (script.facingRight == true)
        
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        else
            rb.AddForce(firePoint.right * -bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);

    }

    void ShotVertical()
    {
       

        
        if (anim.GetBool("lookUp") == true && anim.GetBool("isWalking") == false)
        {
            GameObject bullet = Instantiate(lazerUpDownPrefab, firePoint2.position, firePoint2.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }
            
        if (anim.GetBool("lookDown") == true && anim.GetBool("isWalking") == false)
        {
            GameObject bullet = Instantiate(lazerUpDownPrefab, firePoint3.position, firePoint3.rotation);
            Destroy(bullet, 5f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * -bulletForce, ForceMode2D.Impulse);
        }
            
        
    }
    void ShotDiag()
    {
        

       

        

        if (script.facingRight == true && anim.GetBool("lookUp")==true)
        {
            vertForce = 3 * bulletForce;
            GameObject bullet = Instantiate(lazerDiagPrefab, firePoint4.position, firePoint4.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce + firePoint.right * vertForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }

        if (script.facingRight == false && anim.GetBool("lookUp") == true)
        {
            vertForce = 3 * -bulletForce;
            GameObject bullet = Instantiate(lazerDiagRightPrefab, firePoint4.position, firePoint5.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce + firePoint.right * vertForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }

        if (script.facingRight == true && anim.GetBool("lookDown") == true)
        {
            vertForce = 3 * bulletForce;
            GameObject bullet = Instantiate(lazerDiagDownPrefab, firePoint5.position, firePoint5.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * -bulletForce + firePoint.right * vertForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }

        if (script.facingRight == false && anim.GetBool("lookDown") == true)
        {
            vertForce = 3 * -bulletForce;
            GameObject bullet = Instantiate(lazerDiagDownRightPrefab, firePoint5.position, firePoint5.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * -bulletForce + firePoint.right * vertForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }



    }
    IEnumerator wait()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3f);


    }
   

    
    void Flip()
    {
       

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
    
}
