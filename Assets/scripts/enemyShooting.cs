using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject enemyLazer;
    public GameObject _enemy;
    public Transform firePoint;
    public float bulletForce = 0.01f;
    float fireElapsedTime = 0;
    public float fireDelay = 0.2f;
    private enemyBehavior script;
    // Start is called before the first frame update
    void Start()
    {
        script = _enemy.GetComponent<enemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        fireElapsedTime += Time.deltaTime;

        if (fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            Shot();

        }
    }
    void Shot()
    {
        GameObject bullet = Instantiate(enemyLazer, firePoint.position, firePoint.rotation);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


        if (script.facingRight == true)

            rb.AddForce(firePoint.right * -bulletForce, ForceMode2D.Impulse);
        else
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);

    }
}
